using System.Collections;
using System.Runtime.InteropServices;
using Yoga.Interop;

namespace Yoga; 

public class NodeList : ICollection {
    private Node _node;

    private List<Node> _array = new();

    internal NodeList(Node node) {
        _node = node;
    }

    internal Node Get(int index) {
        return _array[index];
    }

    public void Add(Node node) {
        Insert(Count, node);
    }

    public void Insert(int index, Node node) {
        _node.SetParent(node);
        _array.Insert(index, node);
        unsafe {
            YogaInterop.YGNodeInsertChild(_node, node, (nuint)index);
        }
    }

    public void Remove(Node node) {
        _node.SetParent();
        _array.Remove(node);
        unsafe {
            YogaInterop.YGNodeRemoveChild(_node, node);
        }
    }
    
    public void Clear() {
        foreach (var node in _array) {
            _node.SetParent();
        }
        _array.Clear();
        unsafe {
            YogaInterop.YGNodeRemoveAllChildren(_node);
        }
    }

    public void Set(IEnumerable<Node> nodes) {
        Clear();
        foreach (var node in nodes) {
            Add(node);
        }
    }

    internal void Swap(int index, Node node) {
        _array[index].SetParent();
        _node.SetParent(node);
        _array[index] = node;
        unsafe {
            YogaInterop.YGNodeSwapChild(_node, node, (nuint)index);
        }
    }
    

    public Node this[int index] {
        get => Get(index);
        set => Swap(index, value);
    }


    public IEnumerator<Node> GetEnumerator() {
        return new NodeListEnumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }

    public void CopyTo(Array array, int index = 0) {
        foreach (Node child in this) {
            array.SetValue(child, index++);
        }
    }

    public int Count {
        get {
            unsafe {
                return (int)YogaInterop.YGNodeGetChildCount(_node);
            }
        }
    }
    
    public bool IsSynchronized => false;
    public object SyncRoot => this;
}

internal class NodeListEnumerator : IEnumerator<Node> {

    public bool MoveNext() {
        if (_cursor < _nodeList.Count)
            _cursor++;
        return _cursor != _nodeList.Count;
    }

    public void Reset() {
        _cursor = -1;
    }

    private int _cursor = -1;
    private NodeList _nodeList;

    public NodeListEnumerator(NodeList nodeList) {
        _nodeList = nodeList;
    }

    public Node Current => _nodeList[_cursor];

    object IEnumerator.Current => Current;
    
    public void Dispose() {
        Reset();
        _nodeList = null!;
    }
}