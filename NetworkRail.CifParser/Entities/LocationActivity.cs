namespace NetworkRail.CifParser.Entities
{
    public class LocationActivity
    {
        public bool A { get;  }
        public bool Ae { get;  }
        public bool Bl { get;  }
        public bool C { get;  }
        public bool D { get;  }
        public bool MinusD { get;  }
        public bool E { get;  }
        public bool G { get;  }
        public bool H { get;  }
        public bool Hh { get;  }
        public bool K { get;  }
        public bool Kc { get;  }
        public bool Ke { get;  }
        public bool Kf { get;  }
        public bool Ks { get;  }
        public bool L { get;  }
        public bool N { get;  }
        public bool Op { get;  }
        public bool Or { get;  }
        public bool Pr { get;  }
        public bool R { get;  }
        public bool Rm { get;  }
        public bool Rr { get;  }
        public bool S { get;  }
        public bool T { get;  }
        public bool MinusT { get;  }
        public bool Tb { get;  }
        public bool Tf { get;  }
        public bool Ts { get;  }
        public bool Tw { get;  }
        public bool U { get;  }
        public bool MinusU { get;  }
        public bool W { get;  }
        public bool X { get;  }

        public LocationActivity(string activities)
        {
            for (int i = 0; i < activities.Length; i = i + 2)
            {
                string activity = activities.Substring(i, 2);

                if (activity == "A ")
                    A = true;
                else if (activity == "AE")
                    Ae = true;
                else if (activity == "BL")
                    Bl = true;
                else if (activity == "C ")
                    C = true;
                else if (activity == "D ")
                    D = true;
                else if (activity == "-D")
                    MinusD = true;
                else if (activity == "E ")
                    E = true;
                else if (activity == "G ")
                    G = true;
                else if (activity == "H ")
                    H = true;
                else if (activity == "HH")
                    Hh = true;
                else if (activity == "K ")
                    K = true;
                else if (activity == "KC")
                    Kc = true;
                else if (activity == "KE")
                    Ke = true;
                else if (activity == "KF")
                    Kf = true;
                else if (activity == "KS")
                    Ks = true;
                else if (activity == "L ")
                    L = true;
                else if (activity == "N ")
                    N = true;
                else if (activity == "OP")
                    Op = true;
                else if (activity == "OR")
                    Or = true;
                else if (activity == "PR")
                    Pr = true;
                else if (activity == "R ")
                    R = true;
                else if (activity == "RM")
                    Rm = true;
                else if (activity == "RR")
                    Rr = true;
                else if (activity == "S ")
                    S = true;
                else if (activity == "T ")
                    T = true;
                else if (activity == "-T")
                    MinusT = true;
                else if (activity == "TB")
                    Tb = true;
                else if (activity == "TF")
                    Tf = true;
                else if (activity == "TS")
                    Ts = true;
                else if (activity == "TW")
                    Tw = true;
                else if (activity == "U ")
                    U = true;
                else if (activity == "-U")
                    MinusU = true;
                else if (activity == "W ")
                    W = true;
                else if (activity == "X ")
                    X = true;
            }
        }
    }
}