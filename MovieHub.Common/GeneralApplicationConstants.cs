using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHub.Common
{
    public static class GeneralApplicationConstants
    {
        public static class MovieConstants
        {
            public const int MovieTitleMinLength = 1;//There is a bunch of movies with one character as a name
            public const int MovieTitleMaxLength = 221;//The longest movie name ever created(including spaces)

            public const int DescriptionMinLength = 15;
            public const int DescriptionMaxLength = 1000;
        }
        public static class ActorConstants
        {
            public const int ActorNameMinLength = 1;
            public const int ActorNameMaxLength = 50;

            public const int CityNameMinLength = 1;
            public const int CityNameMaxLength = 58;

            public const int DescriptionMinLength = 15;
            public const int DescriptionMaxLength = 1000;
        }
        public static class RewardConstants
        {
            public const int RewardNameMinLength = 6;
            public const int RewardNameMaxLength = 55;
        }
        public static class DirectorConstants
        {
            public const int DirectorNameMinLength = 1;
            public const int DirectorNameMaxLength = 1000;
        }
        public static class StudioConstants
        {
            public const int StudioNameMinLength = 1;
            public const int StudioNameMaxLength = 50;
        }
        public static class CommentConstants
        {
            public const int CommentMinLength = 1;
            public const int CommentMaxLength = 500;
        }
    }
}
