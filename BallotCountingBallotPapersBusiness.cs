
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.hz.epollbook.datasource.business
{
    public class BallotRemainStatistics : BaseVM
    {
        const string rtfTemplate1 = @"{\rtf1
{\fonttbl 
	{\f0 Arial;}
}
{\colortbl
	;
	\red255\green0\blue0;
	\red0\green0\blue255;
	\red255\green255\blue255;
	\red0\green0\blue0;
}
\sb120\qc\f0\fs24 {0} \f0\fs24\cf1 {1}
}";


        private int allocatedBySupervisor;
        private int spoilt;
        private int issuedToVoters;
        private int actualRemaining;
        private int inReserveSupervisor;
        private int discarded;

        public string IssuePoint { get; set; }
        public DateTime LastSyncedTime { get; set; }
        public string Type { get; set; }
        
        public int AllocatedBySupervisor {
            get => allocatedBySupervisor;
            set
            {
                allocatedBySupervisor = value;
                NotifyPropertyChanged(nameof(ExpectedRemaining));
                NotifyPropertyChanged(nameof(DiffRemaining));
                NotifyPropertyChanged(nameof(ExpectedRemainingAddDiff));
                NotifyPropertyChanged();
            }
        }

        
        public int Spoilt {
            get => spoilt;
            set {
                spoilt = value;
                
                NotifyPropertyChanged(nameof(ExpectedRemaining));
                NotifyPropertyChanged(nameof(DiffRemaining));
                NotifyPropertyChanged(nameof(ExpectedRemainingAddDiff));
                NotifyPropertyChanged();
            }
        }
        
        public int IssuedToVoters {
            get => issuedToVoters;
            set
            {
                issuedToVoters = value;
                NotifyPropertyChanged(nameof(ExpectedRemaining));
                NotifyPropertyChanged(nameof(DiffRemaining));
                NotifyPropertyChanged(nameof(ExpectedRemainingAddDiff));
                
                NotifyPropertyChanged();
            }
        }
        
        public int ActualRemaining
        {
            get => actualRemaining;
            set {
                actualRemaining = value;
                NotifyPropertyChanged(nameof(TotalActualRemaining));
                NotifyPropertyChanged(nameof(DiffRemaining));
                NotifyPropertyChanged(nameof(ExpectedRemainingAddDiff));
                
            }
        }
        

        
        public int InReserveSupervisor
        {
            get => inReserveSupervisor;
            set {
                inReserveSupervisor = value;
                NotifyPropertyChanged(nameof(TotalActualRemaining));
                NotifyPropertyChanged();
            }
        }

        
        public int Discarded {
            get => discarded;
            set {
                discarded = value;
                NotifyPropertyChanged(nameof(TotalActualRemaining));
                NotifyPropertyChanged();
            }
        }

        public int TotalSuppliedByRO { get; set; }


        #region Derived Properties
        

        public int TotalActualRemaining
        {
            get { return ActualRemaining + InReserveSupervisor - Discarded; }
        }

        public int ExpectedRemaining { get { return AllocatedBySupervisor - Spoilt - IssuedToVoters; } }
        public int DiffRemaining { get { return ExpectedRemaining - ActualRemaining; } }

        public string ExpectedRemainingAddDiff {
            get {
                string value = rtfTemplate1.Replace("{0}", ExpectedRemaining + "");
                int diffRemaining = DiffRemaining;
                if (diffRemaining > 0)
                {
                    value = value.Replace("{1}", "(+" + diffRemaining + ")");
                }
                else if (diffRemaining < 0)
                {
                    value = value.Replace("{1}", "(" + diffRemaining + ")");
                }
                else
                {
                    value = value.Replace("{1}", "");
                }
                return value;
            }
        }
        #endregion
    }






    public class BallotCountingBallotPapersBusiness
    {
        

        public List<BallotRemainStatistics> Table1List = new List<BallotRemainStatistics>()
            {

                new BallotRemainStatistics {
                    Type = "District",
                    AllocatedBySupervisor = 600,
                    Spoilt = 10,
                    IssuedToVoters = 490,
                    ActualRemaining = 99,
                },
                new BallotRemainStatistics {
                    Type = "Overprint",
                    AllocatedBySupervisor = 300,
                    Spoilt = 5,
                    IssuedToVoters = 195,
                    ActualRemaining = 100,
                },

                new BallotRemainStatistics {
                    Type = "Handwritten",
                    AllocatedBySupervisor = 0,
                    Spoilt = 0,
                    IssuedToVoters = 0,
                    ActualRemaining = 0,
                },
                
            };

        public BallotRemainStatistics Table1Total = new BallotRemainStatistics
        {
            Type = "Total",
            AllocatedBySupervisor = 600,
            Spoilt = 15,
            IssuedToVoters = 685,
            ActualRemaining = 99,
        };

        

        public List<BallotRemainStatistics> Table2List = new List<BallotRemainStatistics>()        {
                new BallotRemainStatistics
                {
                    Type = "District",
                    ActualRemaining = 99,
                    InReserveSupervisor = 400,
                    Discarded = 2,
                    TotalSuppliedByRO = 1000
                },

                new BallotRemainStatistics
                {
                    Type = "Overpring",
                    ActualRemaining = 100,

                    InReserveSupervisor = 100,
                    
                    Discarded = 4,
                    TotalSuppliedByRO = 600
                },
                new BallotRemainStatistics
                {
                    Type = "Handwritten",
                    ActualRemaining = 0,
                    InReserveSupervisor = 100,
                    
                    Discarded = 0,
                    TotalSuppliedByRO = 100
                }
        };


        public BallotRemainStatistics Table2Total = new BallotRemainStatistics
        {
            Type = "Total",
            ActualRemaining = 199,
            InReserveSupervisor = 600,
            Discarded = 6,
            TotalSuppliedByRO = 1700
        };

        public List<BallotRemainStatistics> Table3ListAll = new List<BallotRemainStatistics>() {
                new BallotRemainStatistics
                {
                    IssuePoint = "Ordinary Issuing Point 1",
                    LastSyncedTime = DateTime.Now,
                    Type = "District",
                    AllocatedBySupervisor = 300,
                    Spoilt = 5,
                    IssuedToVoters = 250,
                    ActualRemaining = 46,
                },

                new BallotRemainStatistics
                {
                    IssuePoint = "Ordinary Issuing Point 2",
                    LastSyncedTime = DateTime.Now,
                    Type = "Handwritten",
                    AllocatedBySupervisor = 0,
                    Spoilt = 0,
                    IssuedToVoters = 0,
                    ActualRemaining = 0,
                },

                new BallotRemainStatistics
                {
                    IssuePoint = "Declaration Issuing Point 1",
                    LastSyncedTime = DateTime.Now,
                    Type = "District",
                    AllocatedBySupervisor = 300,
                    Spoilt = 5,
                    IssuedToVoters = 240,
                    ActualRemaining = 55,
                },
                new BallotRemainStatistics
                {
                    IssuePoint = "Declaration Issuing Point 1",
                    LastSyncedTime = DateTime.Now,
                    Type = "Overpring",
                    AllocatedBySupervisor = 0,
                    Spoilt = 0,
                    IssuedToVoters = 0,
                    ActualRemaining = 0,
                }
        };

        public List<BallotRemainStatistics> Table3ListOwnDistrict = new List<BallotRemainStatistics>() {
                new BallotRemainStatistics
                {
                    IssuePoint = "Ordinary Issuing Point 1",
                    LastSyncedTime = DateTime.Now,
                    Type = "District",
                    AllocatedBySupervisor = 300,
                    Spoilt = 5,
                    IssuedToVoters = 250,
                    ActualRemaining = 46,
                },

                new BallotRemainStatistics
                {
                    IssuePoint = "Ordinary Issuing Point 2",
                    LastSyncedTime = DateTime.Now,
                    Type = "Handwritten",
                    AllocatedBySupervisor = 0,
                    Spoilt = 0,
                    IssuedToVoters = 0,
                    ActualRemaining = 0,
                },
        };

        public List<BallotRemainStatistics> Table3ListOverprint = new List<BallotRemainStatistics>() {
                new BallotRemainStatistics
                {
                    IssuePoint = "Declaration Issuing Point 1",
                    LastSyncedTime = DateTime.Now,
                    Type = "Overpring",
                    AllocatedBySupervisor = 0,
                    Spoilt = 0,
                    IssuedToVoters = 0,
                    ActualRemaining = 0,
                }
                


        };

        public List<BallotRemainStatistics> Table3ListHandwritten = new List<BallotRemainStatistics>() {
                new BallotRemainStatistics
                {
                    IssuePoint = "Ordinary Issuing Point 2",
                    LastSyncedTime = DateTime.Now,
                    Type = "Handwritten",
                    AllocatedBySupervisor = 0,
                    Spoilt = 0,
                    IssuedToVoters = 0,
                    ActualRemaining = 0,
                },
        };

        public BallotCountingBallotPapersBusiness()
        {
            MakeAsTotal(Table1Total, Table1List);
            Table1List.Add(Table1Total);

            MakeAsTotal(Table2Total, Table2List);
            Table2List.Add(Table2Total);
        }

        public void MakeAsTotal(BallotRemainStatistics total, List<BallotRemainStatistics> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != total)
                {
                    list[i].PropertyChanged += (object sender, System.ComponentModel.PropertyChangedEventArgs e) =>
                    {
                        UpdateBallotReamainingOfStaffTotal(total, list);
                    };
                }
            }

            UpdateBallotReamainingOfStaffTotal(total, list);
        }

        private void UpdateBallotReamainingOfStaffTotal(BallotRemainStatistics total, List<BallotRemainStatistics> list)
        {
            total.AllocatedBySupervisor = 0;
            total.Spoilt = 0;
            total.IssuedToVoters = 0;
            total.ActualRemaining = 0;
            Table2Total.InReserveSupervisor = 0;
            Table2Total.Discarded = 0;
            Table2Total.TotalSuppliedByRO = 0;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != total)
                {
                    total.AllocatedBySupervisor += list[i].AllocatedBySupervisor;
                    total.Spoilt += list[i].Spoilt;
                    total.IssuedToVoters += list[i].IssuedToVoters;
                    total.ActualRemaining += list[i].ActualRemaining;
                    Table2Total.InReserveSupervisor += Table2List[i].InReserveSupervisor;
                    Table2Total.Discarded += Table2List[i].Discarded;
                    Table2Total.TotalSuppliedByRO += Table2List[i].TotalSuppliedByRO;
                }
            }
        }

        

    }
}
