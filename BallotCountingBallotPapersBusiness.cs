
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.hz.epollbook.datasource.business
{
    public class BallotCountingBallotPapersBusiness
    {
        public class BallotUsage
        {
            public string Type { get; set; }
            public int AllocatedBySupervisor { get; set; }

            public string MinusPlaceHolder { get; set; }
            public int Spoilt { get; set; }


        
            public string Minus2PlaceHolder { get; set; }
            public int IssuedToVoters { get; set; }

           
            public string EqualPlaceHolder { get; set; }

            public int ExpectedRemaining { get; set; }
            public int DiffOfExpectToRealRemaining { get; set; }

        }

        public List<BallotUsage> BallotUsages = new List<BallotUsage>()
        {
          
            new BallotUsage {
                Type = "District",
                AllocatedBySupervisor = 600,
                Spoilt = 10,
                IssuedToVoters = 490,
                ExpectedRemaining = 100,
                DiffOfExpectToRealRemaining = -1,
                Minus2PlaceHolder = "-",
                MinusPlaceHolder = "-",
                EqualPlaceHolder = "="
            },
            new BallotUsage {
                Type = "Overprint",
                AllocatedBySupervisor = 300,
                Spoilt = 5,
                IssuedToVoters = 195,
                ExpectedRemaining = 100,
                DiffOfExpectToRealRemaining = 1,
                Minus2PlaceHolder = "-",
                MinusPlaceHolder = "-",
                EqualPlaceHolder = "="
            },

            new BallotUsage {
                Type = "Handwritten",
                AllocatedBySupervisor = 0,
                Spoilt = 0,
                IssuedToVoters = 0,
                ExpectedRemaining = 0,
                DiffOfExpectToRealRemaining = 0,
                Minus2PlaceHolder = "-",
                MinusPlaceHolder = "-",
                EqualPlaceHolder = "="
            },
            new BallotUsage {
                Type = "Total",
                AllocatedBySupervisor = 600,
                Spoilt = 15,
                IssuedToVoters = 685,
                ExpectedRemaining = 198,
                DiffOfExpectToRealRemaining = 0,
                Minus2PlaceHolder = "",
                MinusPlaceHolder = "",
                EqualPlaceHolder = ""
            },
        };
    }
}
