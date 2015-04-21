using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolsungHeroCreator
{
    static class PointsToLeveling
    {
        private static int pointsForAttributes = 3;
        public static int PointsForAttributes
        {
            get
            {
                return pointsForAttributes;
            }
        }

        private static int pointsForSkills = 5;
        public static int PointsForSkills 
        {
            get
            {
                return pointsForSkills;
            }
        }

        private static int pointsForSpecialisations = 3;
        public static int PointsForSpecialisations
        {
            get
            {
                return pointsForSpecialisations;
            }
        }

        


        public static bool IncreasePointsForAttributes()
        {
            if (pointsForAttributes < 3)
            {
                pointsForAttributes++;
                return true;
            }

            return false;
        }

        public static bool  DecreasePointsForAttributes()
        {
            if (pointsForAttributes > 0)
            {
                pointsForAttributes--;
                return true;
            }

            return false;
        }


        public static bool IncreasePointsForSkills()
        {
            if (pointsForSkills < 5)
            {
                pointsForSkills++;
                return true;
            }

            return false;
        }

        public static bool DecreasePointsForSkills()
        {
            if (pointsForSkills > 0)
            {
                pointsForSkills--;
                return true;
            }

            return false;
        }

        public static bool IncreasePointsForSpecialisations()
        {
            if (pointsForSpecialisations < 3)
            {
                pointsForSpecialisations++;
                return true;
            }

            return false;
        }

        public static bool DecreasePointsForSpecialisations()
        {
            if (pointsForSpecialisations > 0)
            {
                pointsForSpecialisations--;
                return true;
            }

            return false;
        }
    }
}
