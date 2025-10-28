using BucketClassLibrary.Models.Exceptions;
using System.Net.Sockets;

namespace BucketClassLibrary.Models
{
    public abstract class Container
    {
        public event EventHandler? Full;
        public event EventHandler<OverflowedEventArgs>? Overflowed;
        public event EventHandler<OverflowingEventArgs>? Overflowing;
        public int Capacity { get; init; }
        public int Content { get; private set; } = 0;

        public void Fill(int value)
        {
            Console.WriteLine($"Poging om {value} toe te voegen...");
            int newContent = Content + value;

            if (newContent > Capacity)
            {
                int overflowAmount = newContent - Capacity;

                var args = new OverflowingEventArgs(overflowAmount);
                OnOverflowing(args);

                if (args.Cancel)
                {
                    Console.WriteLine("Overflow geannuleerd door event handler.");
                    return;
                }

                int allowedOverflow = args.AllowedOverflowAmount;
                int added = value - (overflowAmount - allowedOverflow);

                Content = Math.Min(Capacity + allowedOverflow, newContent);

                if (Content >= Capacity)
                {
                    OnFull(EventArgs.Empty);
                }

                OnOverflowed(new OverflowedEventArgs(overflowAmount, allowedOverflow));
            } 
            else if (newContent < 0){
                throw new EmptyContainerException("De container kan geen negatieve hoeveelheid bevatten");
            }
            else
            {
                Content = newContent;
                Console.WriteLine($"Container info: {Content}/{Capacity}");

                if (Content == Capacity)
                {
                    OnFull(EventArgs.Empty);
                }
            }

            /*if (Content + value > Capacity) throw new OverflowException("De container is aan het overstromen");
            else if (Content + value < 0) throw new EmptyContainerException("De container kan niet nogmeer vloeistof verliezen");
            else Content += value;
            if (value > 0)
                Console.WriteLine($"De container wordt gevuld met {value} en bedraagd nu {Content}");
            else
                Console.WriteLine($"De container wordt geleegd met {value} en bedraagd nu {Content}");
*/
        }

        public void Empty()
        {
            Console.WriteLine("De huidige inhoud wordt geleegd");
            Content = 0;
        }

        public void OnFull(EventArgs e)
        {
            Full?.Invoke(this, e);
        }

        public void OnOverflowed(OverflowedEventArgs e)
        {
            Overflowed?.Invoke(this, e);
        }

        public void OnOverflowing(OverflowingEventArgs e)
        {
            Overflowing?.Invoke(this, e);
        }

        public class OverflowedEventArgs : EventArgs
        {
            public int OverflowAmount { get; }
            public int AllowedOverflowAmount { get; }

            public OverflowedEventArgs(int overflowAmount, int allowedOverflowAmount)
            {
                OverflowAmount = overflowAmount;
                AllowedOverflowAmount = allowedOverflowAmount;
            }
        }

        public class OverflowingEventArgs : EventArgs
        {
            public int PredictedOverflowAmount { get; }
            public bool Cancel { get; set; }
            public int AllowedOverflowAmount { get; set; }

            public OverflowingEventArgs(int predictedOverflowAmount)
            {
                PredictedOverflowAmount = predictedOverflowAmount;
                Cancel = false;
                AllowedOverflowAmount = 0;
            }
        }
    }
}
