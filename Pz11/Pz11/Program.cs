using System;


namespace Pz11
{
    public abstract class Equation
    {
        public abstract double Eval();

        public static implicit operator Equation(int source)
        {
            return new Const(source);
        }

    }

    public class Add : Equation
    {
        private Equation left;
        private Equation right;

        public Add(Equation left, Equation right)
        {
            this.left = left;
            this.right = right;
        }

        public override double Eval()
        {
            return left.Eval() + right.Eval();
        }
    }

    public class Subtract : Equation
    {
        private Equation left, right;

        public Subtract(Equation left, Equation right)
        {
            this.left = left;
            this.right = right;
        }
        public override double Eval()
        {
            return right.Eval() - left.Eval();

        }
    }
    public class Mult : Equation
    {
        private Equation left, right;

        public Mult(Equation left, Equation right)
        {
            this.left = left;
            this.right = right;
        }
        public override double Eval()
        {
            return left.Eval() * right.Eval();

        }

    }
    public class Div : Equation
    {

        private Equation left, right;
        

        
        public Div(Equation left, Equation right)
        {
            this.left = left;
            this.right = right;
        }

        
        public override double Eval()
        {
            double denominator = right.Eval();
            if (denominator == 0)
            {
                throw new DivideByZeroException("Ділення на нуль неможливе.");
            }
            return left.Eval() / denominator;
        }
    }

    class Program
    {
       

        static void Main(string[] args)
        {
            Equation equation = new Add(new Const(5), new Mult(10, 4));
            Console.WriteLine(equation.Eval());
        }
    }
    public class Const : Equation

    {
        private int x;
        public Const(int x)
        {
            this.x = x;
        }

        public override double Eval()
        {
            return x;
        }


    }

}
