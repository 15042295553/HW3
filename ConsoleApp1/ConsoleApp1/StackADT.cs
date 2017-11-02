using System;
using System.Collections.Generic;
using System.Text;

public interface StackADT
{
    
    object push(object newItem);

    
    object pop();

    
    object peek();

    
    bool Empty { get; }

    
    void clear();
}