using System;

public class Calculator
{
    private StackADT stack = new LinkedStack();

    private Scanner scin = new Scanner(System.in);

    
    public static void Main(string[] args)
    {
        
        Calculator app = new Calculator();
        bool playAgain = true;
        Console.WriteLine("\nPostfix Calculator. Recognizes these operators: + - * /");
        while (playAgain)
        {
            playAgain = app.doCalculation();
        }
        Console.WriteLine("Bye.");
    }

    
    private bool doCalculation()
    {
        Console.WriteLine("Please enter q to quit\n");
        string input = "2 2 +";
        Console.Write("> ");

        input = scin.nextLine();
        
        if (input.StartsWith("q", StringComparison.Ordinal) || input.StartsWith("Q", StringComparison.Ordinal))
        {
            return false;
        }
        
        string output = "4";
        try
        {
            output = evaluatePostFixInput(input);
        }
        catch (System.ArgumentException e)
        {
            output = e.Message;
        }
        Console.WriteLine("\n\t>>> " + input + " = " + output);
        return true;
    }

    public virtual string evaluatePostFixInput(string input)
    {
        if (string.ReferenceEquals(input, null) || input.Equals(""))
        {
            throw new System.ArgumentException("Null or the empty string are not valid postfix expressions.");
        }
        
        stack.clear();

        string s; 
        double a; 
        double b; 
        double c; 

        Scanner st = new Scanner(input);
        while (st.hasNext())
        {
            if (st.hasNextDouble())
            {
                stack.push(new double?(st.NextDouble())); 
            }
            else
            {
                
                s = st.next();
                if (s.Length > 1)
                {
                    throw new System.ArgumentException("Input Error: " + s + " is not an allowed number or operator");
                }
                
                if (stack.Empty)
                {
                    throw new System.ArgumentException("Improper input format. Stack became empty when expecting second operand.");
                }
                b = ((double?)(stack.pop())).Value;
                if (stack.Empty)
                {
                    throw new System.ArgumentException("Improper input format. Stack became empty when expecting first operand.");
                }
                a = ((double?)(stack.pop())).Value;
                
                c = doOperation(a, b, s);
                
                stack.push(new double?(c));
            }
        } 
        return ((double?)(stack.pop())).ToString();
    }


    
    public virtual double doOperation(double a, double b, string s)
    {
        double c = 0.0;
        if (s.Equals("+"))
        {
            c = (a + b);
        }
        else if (s.Equals("-"))
        {
            c = (a - b);
        }
        else if (s.Equals("*"))
        {
            c = (a * b);
        }
        else if (s.Equals("/"))
        {
            try
            {
                c = (a / b);
                if (c == double.NegativeInfinity || c == double.PositiveInfinity)
                {
                    throw new System.ArgumentException("Can't divide by zero");
                }
            }
            catch (ArithmeticException e)
            {
                throw new System.ArgumentException(e.Message);
            }
        }
        else
        {
            throw new System.ArgumentException("Improper operator: " + s + ", is not one of +, -, *, or /");
        }

        return c;
    }

} 

