using NetworkRail.CifParser.Entities;

namespace NetworkRail.CifParser.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var headerRecord = new HeaderRecord("HDTPS.UDFROC1.PD1512252512152106DFROC2E       FA251215241216                    ");
            var tiplocRecord = new TiplocInsertAmendRecord("TIABER   08381300LABER                      78371   0ABEABER                    ");
            var associationRecord = new AssociationRecord("AANC13005C133261512131601030000001NPSNTNG     TO                               P");

            System.Console.WriteLine(headerRecord);
            System.Console.WriteLine();
            System.Console.WriteLine(tiplocRecord);
            System.Console.WriteLine();
            System.Console.WriteLine(associationRecord);
            System.Console.ReadLine();
        }
    }
}
