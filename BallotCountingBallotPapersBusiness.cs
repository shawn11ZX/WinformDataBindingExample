
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.hz.epollbook.datasource.business
{
    public class BallotCountingBallotPapersBusiness
    {
        public class BallotRemainingOfStaff
        {

            private string type;
            private int allocatedBySupervisor;
            private string minusPlaceHolder;
            private int spoilt;
            private string minus2PlaceHolder;
            private int issuedToVoters;
            private string equalPlaceHolder;
            private int expectedRemaining;
            private int diffOfExpectToRealRemaining;

            public string Type { get => type; set => type = value; }
            public int AllocatedBySupervisor { get => allocatedBySupervisor; set => allocatedBySupervisor = value; }
            public string MinusPlaceHolder { get => minusPlaceHolder; set => minusPlaceHolder = value; }
            public int Spoilt { get => spoilt; set => spoilt = value; }
            public string Minus2PlaceHolder { get => minus2PlaceHolder; set => minus2PlaceHolder = value; }
            public int IssuedToVoters { get => issuedToVoters; set => issuedToVoters = value; }
            public string EqualPlaceHolder { get => equalPlaceHolder; set => equalPlaceHolder = value; }
            public int ExpectedRemaining { get => expectedRemaining; set => expectedRemaining = value; }
            public int DiffOfExpectToRealRemaining { get => diffOfExpectToRealRemaining; set => diffOfExpectToRealRemaining = value; }
        }


        public List<BallotRemainingOfStaff> BallotUsages = new List<BallotRemainingOfStaff>()
            {

                new BallotRemainingOfStaff {
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
                new BallotRemainingOfStaff {
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

                new BallotRemainingOfStaff {
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
                new BallotRemainingOfStaff {
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

        public class BallotRemainingOfRO
        {
            public string Type { get; set; }
            public int ActualRemainingStaff { get; set; }

            public string PlaceHolderPlus { get; set; }
            public string InReserveSupervisor { get; set; }

            public string PlaceHolderMinus { get; set; }
            public int Discarded { get; set; }
            public string PlaceHolderEqual { get; set; }
            public int TotalRemaining { get; set; }
            public string PlaceHodlerOf { get; set; }
            public int TotalSuppliedByRo{ get; set; }
        }

        public List<BallotRemainingOfStaff> BallotUsages2 = new List<BallotRemainingOfStaff>()
        {

            new BallotRemainingOfStaff {
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
            new BallotRemainingOfStaff {
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

            new BallotRemainingOfStaff {
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
            new BallotRemainingOfStaff {
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
