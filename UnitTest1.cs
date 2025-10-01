namespace LinkedDeques;

public class UnitTest1
{

    [Fact]
    public void TestGetLength()
    {
        LinkedList linkedList = new LinkedList(5);
        Assert.Equal(1, linkedList.GetLength());
        linkedList.AddToFront(3);
        Assert.Equal(2, linkedList.GetLength());
    }

    [Fact]
    public void TestAddToFront()
    {
        LinkedList linkedList = new LinkedList(5);
        linkedList.AddToFront(3);
        Assert.Equal(2, linkedList.GetLength());
    }

    [Fact]
    public void TestRemoveFromFront()
    {
        LinkedList linkedList = new LinkedList(5);
        linkedList.AddToFront(3);
        linkedList.AddToFront(4);
        linkedList.RemoveFromFront();
        Assert.Equal(2, linkedList.GetLength());
        Assert.Equal(3, linkedList.GetAtFront());
    }

    [Fact]
    public void TestGetAtFront()
    {
        LinkedList linkedList = new LinkedList(5);
        linkedList.AddToFront(3);
        Assert.Equal(3, linkedList.GetAtFront());
    }

    [Fact]
    public void TestGetAtBack()
    {
        LinkedList linkedList = new LinkedList(5);
        linkedList.AddToFront(3);
        Assert.Equal(5, linkedList.GetAtBack());
    }

    [Fact]
    public void TestAddToBack()
    {
        LinkedList linkedList = new LinkedList(5);
        linkedList.AddToBack(4);
        linkedList.AddToBack(3);
        Assert.Equal(3, linkedList.GetAtBack());
        Assert.Equal(5, linkedList.GetAtFront());
    }

    [Fact]
    public void TestRemoveFromBack()
    {
        LinkedList linkedList = new LinkedList(5);
        linkedList.AddToBack(3);
        linkedList.AddToBack(4);
        linkedList.RemoveFromBack();
        Assert.Equal(2, linkedList.GetLength());
        Assert.Equal(3, linkedList.GetAtBack());
    }
}



class LinkedList
{
    private class Node
    {
        public int Value;
        public Node Next;
        public Node Previous;
    }

    private Node Head = null;
    private Node Tail = null;

    public LinkedList(int value)
    {
        Node node = new Node();
        Head = node;
        Tail = node;
        node.Value = value;
    }

    private int LengthRec(Node head)
    {
        if (head is null) return 0;
        return 1 + LengthRec(head.Next);
    }

    public int GetLength()
    {
        return LengthRec(Head);
    }

    public void AddToFront(int value)
    {
        Node node = new Node();
        node.Next = Head;
        Head = node;
        node.Value = value;

        if (GetLength() == 2)
        {
            Tail = Head.Next;
            Tail.Previous = Head;
        }
    }

    public void RemoveFromFront()
    {
        Head = Head.Next;
    }

    public int GetAtFront()
    {
        return Head.Value;
    }

    public int GetAtBack()
    {
        return Tail.Value;
    }

    public void AddToBack(int value)
    {
        Node node = new Node();
        node.Previous = Tail;
        Tail = node;
        node.Value = value;

        if (GetLength() + 1 == 2)
        {
            Head = Tail.Previous;
            Head.Next = Tail;
        }
    }

    public void RemoveFromBack()
    {
        Tail = Tail.Previous;
        if (GetLength() == 1)
        {
            Head.Next = null;
        }
    }
}
