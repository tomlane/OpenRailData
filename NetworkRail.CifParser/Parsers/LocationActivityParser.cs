using System;
using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser.Parsers
{
    public class LocationActivityParser : ILocationActivityParser
    {
        public LocationActivity ParseActivity(string activities)
        {
            if (activities == null)
                throw new ArgumentNullException(nameof(activities));

            LocationActivity locationActivity = new LocationActivity();

            for (int i = 0; i < activities.Length; i = i + 2)
            {
                string activity = activities.Substring(i, 2);

                if (activity == "A ")
                    locationActivity.A = true;
                else if (activity == "AE")
                    locationActivity.Ae = true;
                else if (activity == "BL")
                    locationActivity.Bl = true;
                else if (activity == "C ")
                    locationActivity.C = true;
                else if (activity == "D ")
                    locationActivity.D = true;
                else if (activity == "-D")
                    locationActivity.MinusD = true;
                else if (activity == "E ")
                    locationActivity.E = true;
                else if (activity == "G ")
                    locationActivity.G = true;
                else if (activity == "H ")
                    locationActivity.H = true;
                else if (activity == "HH")
                    locationActivity.Hh = true;
                else if (activity == "K ")
                    locationActivity.K = true;
                else if (activity == "KC")
                    locationActivity.Kc = true;
                else if (activity == "KE")
                    locationActivity.Ke = true;
                else if (activity == "KF")
                    locationActivity.Kf = true;
                else if (activity == "KS")
                    locationActivity.Ks = true;
                else if (activity == "L ")
                    locationActivity.L = true;
                else if (activity == "N ")
                    locationActivity.N = true;
                else if (activity == "OP")
                    locationActivity.Op = true;
                else if (activity == "OR")
                    locationActivity.Or = true;
                else if (activity == "PR")
                    locationActivity.Pr = true;
                else if (activity == "R ")
                    locationActivity.R = true;
                else if (activity == "RM")
                    locationActivity.Rm = true;
                else if (activity == "RR")
                    locationActivity.Rr = true;
                else if (activity == "S ")
                    locationActivity.S = true;
                else if (activity == "T ")
                    locationActivity.T = true;
                else if (activity == "-T")
                    locationActivity.MinusT = true;
                else if (activity == "TB")
                    locationActivity.Tb = true;
                else if (activity == "TF")
                    locationActivity.Tf = true;
                else if (activity == "TS")
                    locationActivity.Ts = true;
                else if (activity == "TW")
                    locationActivity.Tw = true;
                else if (activity == "U ")
                    locationActivity.U = true;
                else if (activity == "-U")
                    locationActivity.MinusU = true;
                else if (activity == "W ")
                    locationActivity.W = true;
                else if (activity == "X ")
                    locationActivity.X = true;
            }

            return locationActivity;
        }
    }
}