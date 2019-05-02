
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
            public string PlaceHolderMinus { get => minusPlaceHolder; set => minusPlaceHolder = value; }
            public int Spoilt { get => spoilt; set => spoilt = value; }
            public string PlaceHolderMinus2 { get => minus2PlaceHolder; set => minus2PlaceHolder = value; }
            public int IssuedToVoters { get => issuedToVoters; set => issuedToVoters = value; }
            public string PlaceHolderEqual { get => equalPlaceHolder; set => equalPlaceHolder = value; }
            public int ExpectedRemaining { get => expectedRemaining; set => expectedRemaining = value; }
            public int DiffOfExpectToRealRemaining { get => diffOfExpectToRealRemaining; set => diffOfExpectToRealRemaining = value; }
        }


        public List<BallotRemainingOfStaff> BallotRemainingOfStaffs = new List<BallotRemainingOfStaff>()
            {

                new BallotRemainingOfStaff {
                    Type = "District",
                    AllocatedBySupervisor = 600,
                    Spoilt = 10,
                    IssuedToVoters = 490,
                    ExpectedRemaining = 100,
                    DiffOfExpectToRealRemaining = -1,
                    PlaceHolderMinus2 = "-",
                    PlaceHolderMinus = "-",
                    PlaceHolderEqual = "="
                },
                new BallotRemainingOfStaff {
                    Type = "Overprint",
                    AllocatedBySupervisor = 300,
                    Spoilt = 5,
                    IssuedToVoters = 195,
                    ExpectedRemaining = 100,
                    DiffOfExpectToRealRemaining = 1,
                    PlaceHolderMinus2 = "-",
                    PlaceHolderMinus = "-",
                    PlaceHolderEqual = "="
                },

                new BallotRemainingOfStaff {
                    Type = "Handwritten",
                    AllocatedBySupervisor = 0,
                    Spoilt = 0,
                    IssuedToVoters = 0,
                    ExpectedRemaining = 0,
                    DiffOfExpectToRealRemaining = 0,
                    PlaceHolderMinus2 = "-",
                    PlaceHolderMinus = "-",
                    PlaceHolderEqual = "="
                },
                
            };

        public BallotRemainingOfStaff BallotRemainingOfStaffTotal = new BallotRemainingOfStaff
        {
            Type = "Total",
            AllocatedBySupervisor = 600,
            Spoilt = 15,
            IssuedToVoters = 685,
            ExpectedRemaining = 198,
            DiffOfExpectToRealRemaining = 0,
            PlaceHolderMinus2 = "",
            PlaceHolderMinus = "",
            PlaceHolderEqual = ""
        };

        public class BallotRemainingOfBooth : BaseVM
        {
            public string Type { get; set; }
            public int ActualRemainingStaff { get; set; }
            public string PlaceHolderPlus { get; set; }
            private int inReserveSupervisor;
            public int InReserveSupervisor {
                get => inReserveSupervisor;
                set { inReserveSupervisor = value; NotifyPropertyChanged("TotalRemaining"); }
            }
            public string PlaceHolderMinus { get; set; }
            private int discarded;
            public int Discarded { get => discarded; set { discarded = value; NotifyPropertyChanged("TotalRemaining"); } }
            public string PlaceHolderEqual { get; set; }
            
            public int TotalRemaining
            {
                get { return ActualRemainingStaff + InReserveSupervisor - Discarded; }
            }
            public string PlaceHodlerOf { get; set; }
            public int TotalSuppliedByRo{ get; set; }
        }

        public List<BallotRemainingOfBooth> BallotRemainingOfBooths = new List<BallotRemainingOfBooth>()        {
                new BallotRemainingOfBooth
                {
                    Type = "District",
                    ActualRemainingStaff = 99,
                    PlaceHolderPlus = "+",
                    InReserveSupervisor = 400,
                    PlaceHolderMinus = "-",
                    Discarded = 2,
                    PlaceHolderEqual  = "=",
                    PlaceHodlerOf = "of",

                    TotalSuppliedByRo = 1000
                },

                new BallotRemainingOfBooth
                {
                    Type = "Overpring",
                    ActualRemainingStaff = 100,
                    PlaceHolderPlus = "+",
                    InReserveSupervisor = 100,
                    PlaceHolderMinus = "-",
                    Discarded = 4,
                    PlaceHolderEqual  = "=",
                    PlaceHodlerOf = "of",

                    TotalSuppliedByRo = 600
                },
                new BallotRemainingOfBooth
                {
                    Type = "Handwritten",
                    ActualRemainingStaff = 0,
                    PlaceHolderPlus = "+",
                    InReserveSupervisor = 100,
                    PlaceHolderMinus = "-",
                    Discarded = 0,
                    PlaceHolderEqual  = "=",
                    PlaceHodlerOf = "of",
                    TotalSuppliedByRo = 100
                }
        };

        public BallotRemainingOfBooth BallotRemainingOfBoothTotal = new BallotRemainingOfBooth
        {
            Type = "Total",
            ActualRemainingStaff = 199,
            PlaceHolderPlus = "",
            InReserveSupervisor = 600,
            PlaceHolderMinus = "",
            Discarded = 6,
            PlaceHodlerOf = "of",

            TotalSuppliedByRo = 1700
        };

        public BallotCountingBallotPapersBusiness()
        {
            
            BallotRemainingOfStaffs.Add(BallotRemainingOfStaffTotal);
            UpdateBallotReamainingOfStaffTotal();

            for (int i = 0; i < BallotRemainingOfBooths.Count; i++)
            {
                BallotRemainingOfBooths[i].PropertyChanged += BallotCountingBallotPapersBusiness_PropertyChanged;
            }
            BallotRemainingOfBooths.Add(BallotRemainingOfBoothTotal);
            UpdateBallotReamainingOfBoothTotal();
        }

        private void UpdateBallotReamainingOfStaffTotal()
        {
            BallotRemainingOfStaffTotal.AllocatedBySupervisor = 0;
            BallotRemainingOfStaffTotal.Spoilt = 0;
            BallotRemainingOfStaffTotal.IssuedToVoters = 0;
            BallotRemainingOfStaffTotal.ExpectedRemaining = 0;
            BallotRemainingOfStaffTotal.DiffOfExpectToRealRemaining = 0;

            for (int i = 0; i < BallotRemainingOfStaffs.Count; i++)
            {
                if (BallotRemainingOfStaffs[i] != BallotRemainingOfStaffTotal)
                {
                    BallotRemainingOfStaffTotal.AllocatedBySupervisor += BallotRemainingOfStaffs[i].AllocatedBySupervisor;
                    BallotRemainingOfStaffTotal.Spoilt += BallotRemainingOfStaffs[i].Spoilt;
                    BallotRemainingOfStaffTotal.IssuedToVoters += BallotRemainingOfStaffs[i].IssuedToVoters;
                    BallotRemainingOfStaffTotal.ExpectedRemaining += BallotRemainingOfStaffs[i].ExpectedRemaining;
                    BallotRemainingOfStaffTotal.DiffOfExpectToRealRemaining += BallotRemainingOfStaffs[i].DiffOfExpectToRealRemaining;
                }
            }
        }

        private void BallotCountingBallotPapersBusiness_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            UpdateBallotReamainingOfBoothTotal();
        }

        private void UpdateBallotReamainingOfBoothTotal()
        {
            BallotRemainingOfBoothTotal.ActualRemainingStaff = 0;
            BallotRemainingOfBoothTotal.InReserveSupervisor = 0;
            BallotRemainingOfBoothTotal.Discarded = 0;
            BallotRemainingOfBoothTotal.TotalSuppliedByRo = 0;

            for (int i = 0; i < BallotRemainingOfBooths.Count; i++)
            {
                if (BallotRemainingOfBooths[i] != BallotRemainingOfBoothTotal)
                {
                    BallotRemainingOfBoothTotal.ActualRemainingStaff += BallotRemainingOfBooths[i].ActualRemainingStaff;
                    BallotRemainingOfBoothTotal.InReserveSupervisor += BallotRemainingOfBooths[i].InReserveSupervisor;
                    BallotRemainingOfBoothTotal.Discarded += BallotRemainingOfBooths[i].Discarded;
                    BallotRemainingOfBoothTotal.TotalSuppliedByRo += BallotRemainingOfBooths[i].TotalSuppliedByRo;
                }
            }
        }
    }
}
