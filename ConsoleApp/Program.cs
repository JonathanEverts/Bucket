using BucketClassLibrary.Models;
using static BucketClassLibrary.Models.Container;

/*Bucket b = new Bucket();
Bucket b26 = new Bucket(26);

Oilbarrel ob = new Oilbarrel();

Rainbarrel rbl = new Rainbarrel(Capacity.Large);
try
{
    b.Fill(27);
} catch (OverflowException ex)
{
    Console.WriteLine(ex.ToString());
}

b26.Fill(26);
ob.Fill(123);
rbl.Fill(10);
rbl.Fill(24);*/

Bucket container = new Bucket(100);

// Subscribe to the Full event
container.Full += OnContainerFull;
container.Overflowing += OnContainerOverflowing;
container.Overflowed += OnContainerOverflowed;

container.Fill(60);
container.Fill(50); // This will trigger the Full event

static void OnContainerFull(object sender, EventArgs e)
{
    var c = (Container)sender;
    Console.WriteLine($"Container (Capaciteit={c.Capacity}) is nu vol");
}

static void OnContainerOverflowing(object sender, OverflowingEventArgs e)
{
    var c = (Container)sender;
    Console.WriteLine("De container is aan het overstromen");
}

static void OnContainerOverflowed(object sender, OverflowedEventArgs e)
{
    var c = (Container)sender;
    Console.WriteLine("De container is overstroomd");
}