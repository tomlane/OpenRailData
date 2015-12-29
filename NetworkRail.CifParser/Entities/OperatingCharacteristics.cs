namespace NetworkRail.CifParser.Entities
{
    public class OperatingCharacteristics
    {
        public bool B { get; }
        public bool C { get; }
        public bool D { get; }
        public bool E { get; }
        public bool G { get; }
        public bool M { get; }
        public bool P { get; }
        public bool Q { get; }
        public bool R { get; }
        public bool S { get; }
        public bool Y { get; }
        public bool Z { get; }

        public OperatingCharacteristics(string characteristics)
        {
            B = false;
            C = false;
            D = false;
            E = false;
            G = false;
            M = false;
            P = false;
            Q = false;
            R = false;
            S = false;
            Y = false;
            Z = false;

            foreach (var oc in characteristics)
            {
                if (oc == 'B')
                    B = true;
                else if (oc == 'C')
                    C = true;
                else if (oc == 'D')
                    D = true;
                else if (oc == 'E')
                    E = true;
                else if (oc == 'G')
                    G = true;
                else if (oc == 'M')
                    M = true;
                else if (oc == 'P')
                    P = true;
                else if (oc == 'Q')
                    Q = true;
                else if (oc == 'R')
                    R = true;
                else if (oc == 'S')
                    S = true;
                else if (oc == 'Y')
                    Y = true;
                else if (oc == 'Z')
                    Z = true;
            }
        }
    }
}