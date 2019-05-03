
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
\f0\fs22 {0} \f0\fs22\cf1 {1}
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



    public enum Table3Type { All, OwnDistrict, Overprint, Handwritten }

    public interface IBallotCountingBallotPapersBusiness : INotifyPropertyChanged
    {
        
        IList<BallotRemainStatistics> Table1List { get; }
        IList<BallotRemainStatistics> Table2List { get; }
        IList<BallotRemainStatistics> Table3List { get; }
        void SelectTable3(Table3Type type);
    }

    public class BallotCountingBallotPapersBusiness : IBallotCountingBallotPapersBusiness
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public IList<BallotRemainStatistics> table1List;
        public IList<BallotRemainStatistics> Table1List
        {
            get => table1List;
            set
            {
                table1List = value;
                NotifyPropertyChanged();
            }
        }

        public IList<BallotRemainStatistics> table2List;
        public IList<BallotRemainStatistics> Table2List
        {
            get => table2List;
            set
            {
                table2List = value;
                NotifyPropertyChanged();
            }
        }

        public IList<BallotRemainStatistics> table3List;
        public IList<BallotRemainStatistics> Table3List
        {
            get => table3List;
            set
            {
                table3List = value;
                NotifyPropertyChanged();
            }
        }

        public BallotCountingBallotPapersBusiness()
        {
            Table1List = new BindingList<BallotRemainStatistics>()
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

            Table2List = new BindingList<BallotRemainStatistics>()        {
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

            MakeAsTotal(Table1Total, Table1List);
            Table1List.Add(Table1Total);

            MakeAsTotal(Table2Total, Table2List);
            Table2List.Add(Table2Total);

            Table3List = Table3ListAll;
        }

        public void SelectTable3(Table3Type type)
        {
            switch(type)
            {
                case Table3Type.All:
                    Table3List = Table3ListAll;
                    break;
                case Table3Type.OwnDistrict:
                    Table3List = Table3ListOwnDistrict;
                    break;
                case Table3Type.Overprint:
                    Table3List = Table3ListOverprint;
                    break;
                case Table3Type.Handwritten:
                    Table3List = Table3ListHandwritten;
                    break;
            }
        }
        private BallotRemainStatistics Table1Total = new BallotRemainStatistics
        {
            Type = "Total",
            AllocatedBySupervisor = 600,
            Spoilt = 15,
            IssuedToVoters = 685,
            ActualRemaining = 99,
        };

        

        private BallotRemainStatistics Table2Total = new BallotRemainStatistics
        {
            Type = "Total",
            ActualRemaining = 199,
            InReserveSupervisor = 600,
            Discarded = 6,
            TotalSuppliedByRO = 1700
        };

        private BindingList<BallotRemainStatistics> Table3ListAll = new BindingList<BallotRemainStatistics>() {
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

        private BindingList<BallotRemainStatistics> Table3ListOwnDistrict = new BindingList<BallotRemainStatistics>() {
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

        private BindingList<BallotRemainStatistics> Table3ListOverprint = new BindingList<BallotRemainStatistics>() {
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

        private BindingList<BallotRemainStatistics> Table3ListHandwritten = new BindingList<BallotRemainStatistics>() {
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



        private void MakeAsTotal(BallotRemainStatistics total, IList<BallotRemainStatistics> BindingList)
        {
            for (int i = 0; i < BindingList.Count; i++)
            {
                if (BindingList[i] != total)
                {
                    BindingList[i].PropertyChanged += (object sender, System.ComponentModel.PropertyChangedEventArgs e) =>
                    {
                        UpdateBallotReamainingOfStaffTotal(total, BindingList);
                    };
                }
            }

            UpdateBallotReamainingOfStaffTotal(total, BindingList);
        }

        private void UpdateBallotReamainingOfStaffTotal(BallotRemainStatistics total, IList<BallotRemainStatistics> BindingList)
        {
            total.AllocatedBySupervisor = 0;
            total.Spoilt = 0;
            total.IssuedToVoters = 0;
            total.ActualRemaining = 0;
            Table2Total.InReserveSupervisor = 0;
            Table2Total.Discarded = 0;
            Table2Total.TotalSuppliedByRO = 0;

            for (int i = 0; i < BindingList.Count; i++)
            {
                if (BindingList[i] != total)
                {
                    total.AllocatedBySupervisor += BindingList[i].AllocatedBySupervisor;
                    total.Spoilt += BindingList[i].Spoilt;
                    total.IssuedToVoters += BindingList[i].IssuedToVoters;
                    total.ActualRemaining += BindingList[i].ActualRemaining;
                    Table2Total.InReserveSupervisor += Table2List[i].InReserveSupervisor;
                    Table2Total.Discarded += Table2List[i].Discarded;
                    Table2Total.TotalSuppliedByRO += Table2List[i].TotalSuppliedByRO;
                }
            }
        }

        

    }
}
