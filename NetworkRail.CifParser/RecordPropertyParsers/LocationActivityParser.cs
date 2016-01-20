using System;
using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.RecordPropertyParsers
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
                    locationActivity = locationActivity | LocationActivity.A;
                else if (activity == "AE")
                    locationActivity = locationActivity | LocationActivity.AE;
                else if (activity == "BL")
                    locationActivity = locationActivity | LocationActivity.BL;
                else if (activity == "C ")
                    locationActivity = locationActivity | LocationActivity.C;
                else if (activity == "D ")
                    locationActivity = locationActivity | LocationActivity.D;
                else if (activity == "-D")
                    locationActivity = locationActivity | LocationActivity.MinusD;
                else if (activity == "E ")
                    locationActivity = locationActivity | LocationActivity.E;
                else if (activity == "G ")
                    locationActivity = locationActivity | LocationActivity.G;
                else if (activity == "H ")
                    locationActivity = locationActivity | LocationActivity.H;
                else if (activity == "HH")
                    locationActivity = locationActivity | LocationActivity.HH;
                else if (activity == "K ")
                    locationActivity = locationActivity | LocationActivity.K;
                else if (activity == "KC")
                    locationActivity = locationActivity | LocationActivity.KC;
                else if (activity == "KE")
                    locationActivity = locationActivity | LocationActivity.KE;
                else if (activity == "KF")
                    locationActivity = locationActivity | LocationActivity.KF;
                else if (activity == "KS")
                    locationActivity = locationActivity | LocationActivity.KS;
                else if (activity == "L ")
                    locationActivity = locationActivity | LocationActivity.L;
                else if (activity == "N ")
                    locationActivity = locationActivity | LocationActivity.N;
                else if (activity == "OP")
                    locationActivity = locationActivity | LocationActivity.OP;
                else if (activity == "OR")
                    locationActivity = locationActivity | LocationActivity.OR;
                else if (activity == "PR")
                    locationActivity = locationActivity | LocationActivity.PR;
                else if (activity == "R ")
                    locationActivity = locationActivity | LocationActivity.R;
                else if (activity == "RM")
                    locationActivity = locationActivity | LocationActivity.RM;
                else if (activity == "RR")
                    locationActivity = locationActivity | LocationActivity.RR;
                else if (activity == "S ")
                    locationActivity = locationActivity | LocationActivity.S;
                else if (activity == "T ")
                    locationActivity = locationActivity | LocationActivity.T;
                else if (activity == "-T")
                    locationActivity = locationActivity | LocationActivity.MinusT;
                else if (activity == "TB")
                    locationActivity = locationActivity | LocationActivity.TB;
                else if (activity == "TF")
                    locationActivity = locationActivity | LocationActivity.TF;
                else if (activity == "TS")
                    locationActivity = locationActivity | LocationActivity.TS;
                else if (activity == "TW")
                    locationActivity = locationActivity | LocationActivity.TW;
                else if (activity == "U ")
                    locationActivity = locationActivity | LocationActivity.U;
                else if (activity == "-U")
                    locationActivity = locationActivity | LocationActivity.MinusU;
                else if (activity == "W ")
                    locationActivity = locationActivity | LocationActivity.W;
                else if (activity == "X ")
                    locationActivity = locationActivity | LocationActivity.X;
            }

            return locationActivity;
        }
    }
}