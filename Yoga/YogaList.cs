using System.Collections;
using System.Runtime.InteropServices;
using Yoga.Interop;

namespace Yoga; 

public class YogaNodeList : ICollection {
    private YogaNode _node;
    private unsafe void* _pointer => _node.RawPointer;

    private List<YogaNode> _array = new();

    internal YogaNodeList(YogaNode node) {
        _node = node;
    }

    internal YogaNode Get(int index) {
        return _array[index];
    }

    public void Add(YogaNode node) {
        _node._owner = node;
        Insert(Count, node);
    }

    public void Insert(int index, YogaNode node) {
        _array.Insert(index, node);
        unsafe {
            YogaInterop.YGNodeInsertChild(_pointer, node.RawPointer, new((uint)index));
        }
    }

    public void Remove(YogaNode node) {
        _array.Remove(node);
        unsafe {
            YogaInterop.YGNodeRemoveChild(_pointer, node.RawPointer);
        }
    }

    internal void Swap(int index, YogaNode node) {
        _array[index] = node;
        unsafe {
            YogaInterop.YGNodeSwapChild(_pointer, node.RawPointer, new((uint)index));
        }
    }
    

    public YogaNode this[int index] {
        get => Get(index);
        set => Swap(index, value);
    }


    public IEnumerator<YogaNode> GetEnumerator() {
        return new YogaListEnumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }

    public void CopyTo(Array array, int index = 0) {
        foreach (YogaNode child in this) {
            array.SetValue(child, index++);
        }
    }

    public int Count {
        get {
            unsafe {
                return (int)YogaInterop.YGNodeGetChildCount(_pointer);
            }
        }
    }
    
    public bool IsSynchronized => false;
    public object SyncRoot => this;
}

internal class YogaListEnumerator : IEnumerator<YogaNode> {

    public bool MoveNext() {
        if (_cursor < _nodeList.Count)
            _cursor++;
        return _cursor != _nodeList.Count;
    }

    public void Reset() {
        _cursor = -1;
    }

    private int _cursor = -1;
    private YogaNodeList _nodeList;

    public YogaListEnumerator(YogaNodeList yogaNodeList) {
        _nodeList = yogaNodeList;
    }

    public YogaNode Current => _nodeList[_cursor];

    object IEnumerator.Current => Current;
    
    public void Dispose() {
        Reset();
        _nodeList = null!;
    }
}