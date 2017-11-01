using System;
using System.Collections.Generic;
using System.Text;

public class LinkedStack : StackADT
{
    private Node top;

    public LinkedStack()
    {
        top = null; // Empty stack condition
    }

    public virtual object push(object newItem)
    {
        if (newItem == null)
        {
            return null;
        }
        Node newNode = new Node(newItem, top);
        top = newNode;
        return newItem;
    }

    public virtual object pop()
    {
        if (Empty)
        {
            return null;
        }
        object topItem = top.data;
        top = top.next;
        return topItem;
    }

    public virtual object peek()
    {
        if (Empty)
        {
            return null;
        }
        return top.data;
    }

    public virtual bool Empty
    {
        get
        {
            return top == null;
        }
    }

    public virtual void clear()
    {
        top = null;
    }

}

