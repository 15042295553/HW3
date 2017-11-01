using System;
using System.Collections.Generic;
using System.Text;

public class Node
{
    public object data; // The payload
    public Node next; // Reference to the next Node in the chain

    public Node()
    {
        data = null;
        next = null;
    }

    public Node(object data, Node next)
    {
        this.data = data;
        this.next = next;
    }
}
