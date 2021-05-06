using System;
using System.Collections.Generic;
using System.Text;

namespace Degree_Planner
{
    public class Terms
    {
        public static IEnumerable<TermGroup> GetTerms()
        {
            return null;
            //return new List<TermGroup> {
            //    new TermGroup(new Term("Term 1", true, DateTime.Now, DateTime.Now.AddDays(10), new List<Course> {
            //        new Course("Software 1", CourseStatus.Completed, "Karth Onasi", "(801)-999-9999", "karth@gmail.com", 6, DateTime.Now, DateTime.Now.AddDays(10), new List<Assessment> {
            //            new Assessment("Some Test", AssessmentType.Objective, true, DateTime.Now, DateTime.Now.AddDays(10)),
            //            new Assessment("Another Test", AssessmentType.Performance, true, DateTime.Now, DateTime.Now.AddDays(10))
            //        }, new List<Note> {
            //            new Note("Some Note", "This is a note. Neat aye?"),
            //            new Note("Another Note", "So i've multiple Labels already created and i want to bind each label.text to an item of a list as the code shows. but it seems that i can't access the value of items by index")
            //        }),
            //        new Course("Software 2", CourseStatus.InProgress, "Rick Okanal", "(801)-999-9999", "karth@gmail.com", 6, DateTime.Now, DateTime.Now.AddDays(10), new List<Assessment> {
            //            new Assessment("Some Test", AssessmentType.Objective, true, DateTime.Now, DateTime.Now.AddDays(10)),
            //            new Assessment("Another Test", AssessmentType.Performance, false, DateTime.Now, DateTime.Now.AddDays(10))
            //        }, new List<Note> {
            //            new Note("Some Note", "This is a note. Neat aye?"),
            //            new Note("Another Note", "Heres another note. Less neat I'd say.")
            //        }),
            //        new Course("Software 1", CourseStatus.InProgress, "Garosh Hellscream", "(801)-999-9999", "karth@gmail.com", 6, DateTime.Now, DateTime.Now.AddDays(10), new List<Assessment> {
            //            new Assessment("Some Test", AssessmentType.Objective, false, DateTime.Now, DateTime.Now.AddDays(10))
            //        }, new List<Note> {
            //            new Note("Some Note", "This is a note. Neat aye?"),
            //            new Note("Another Note", "Heres another note. Less neat I'd say.")
            //        }),
            //        new Course("Software 1", CourseStatus.Dropped, "Benedict Cumberbatch", "(801)-999-9999", "karth@gmail.com", 6, DateTime.Now, DateTime.Now.AddDays(10), new List<Assessment> {
            //            new Assessment("Another Test", AssessmentType.Performance, false, DateTime.Now, DateTime.Now.AddDays(10))
            //        }, new List<Note> {
            //            new Note("Some Note", "This is a note. Neat aye?"),
            //            new Note("Another Note", "Heres another note. Less neat I'd say.")
            //        }),
            //        new Course("Software 1", CourseStatus.PlanToTake, "Bilbo Baggins", "(801)-999-9999", "karth@gmail.com", 6, DateTime.Now, DateTime.Now.AddDays(10), new List<Assessment> {
            //            new Assessment("Some Test", AssessmentType.Objective, false, DateTime.Now, DateTime.Now.AddDays(10)),
            //            new Assessment("Another Test", AssessmentType.Performance, false, DateTime.Now, DateTime.Now.AddDays(10))
            //        }, new List<Note> {
            //            new Note("Some Note", "This is a note. Neat aye?"),
            //            new Note("Another Note", "Heres another note. Less neat I'd say.")
            //        }),
            //        new Course("Software 1", CourseStatus.InProgress, "Karth Onasi", "(801)-999-9999", "karth@gmail.com", 6, DateTime.Now, DateTime.Now.AddDays(10), new List<Assessment> {
            //            new Assessment("Some Test", AssessmentType.Objective, false, DateTime.Now, DateTime.Now.AddDays(10)),
            //            new Assessment("Another Test", AssessmentType.Performance, false, DateTime.Now, DateTime.Now.AddDays(10))
            //        }, new List<Note> {
            //            new Note("Some Note", "This is a note. Neat aye?"),
            //            new Note("Another Note", "Heres another note. Less neat I'd say.")
            //        })
            //    })),
            //    new TermGroup(new Term("Term 2", true, DateTime.Now, DateTime.Now.AddDays(10), new List<Course> {
            //        new Course("Software 1", CourseStatus.InProgress, "Karth Onasi", "(801)-999-9999", "karth@gmail.com", 6, DateTime.Now, DateTime.Now.AddDays(10), new List<Assessment> {
            //            new Assessment("Some Test", AssessmentType.Objective, false, DateTime.Now, DateTime.Now.AddDays(10)),
            //            new Assessment("Another Test", AssessmentType.Performance, false, DateTime.Now, DateTime.Now.AddDays(10))
            //        }, new List<Note> {
            //            new Note("Some Note", "This is a note. Neat aye?"),
            //            new Note("Another Note", "Heres another note. Less neat I'd say.")
            //        }),
            //        new Course("Software 1", CourseStatus.InProgress, "Karth Onasi", "(801)-999-9999", "karth@gmail.com", 6, DateTime.Now, DateTime.Now.AddDays(10), new List<Assessment> {
            //            new Assessment("Some Test", AssessmentType.Objective, false, DateTime.Now, DateTime.Now.AddDays(10)),
            //            new Assessment("Another Test", AssessmentType.Performance, false, DateTime.Now, DateTime.Now.AddDays(10))
            //        }, new List<Note> {
            //            new Note("Some Note", "This is a note. Neat aye?"),
            //            new Note("Another Note", "Heres another note. Less neat I'd say.")
            //        }),
            //        new Course("Software 1", CourseStatus.InProgress, "Karth Onasi", "(801)-999-9999", "karth@gmail.com", 6, DateTime.Now, DateTime.Now.AddDays(10), new List<Assessment> {
            //            new Assessment("Some Test", AssessmentType.Objective, false, DateTime.Now, DateTime.Now.AddDays(10)),
            //            new Assessment("Another Test", AssessmentType.Performance, false, DateTime.Now, DateTime.Now.AddDays(10))
            //        }, new List<Note> {
            //            new Note("Some Note", "This is a note. Neat aye?"),
            //            new Note("Another Note", "Heres another note. Less neat I'd say.")
            //        }),
            //        new Course("Software 1", CourseStatus.InProgress, "Karth Onasi", "(801)-999-9999", "karth@gmail.com", 6, DateTime.Now, DateTime.Now.AddDays(10), new List<Assessment> {
            //            new Assessment("Some Test", AssessmentType.Objective, false, DateTime.Now, DateTime.Now.AddDays(10)),
            //            new Assessment("Another Test", AssessmentType.Performance, false, DateTime.Now, DateTime.Now.AddDays(10))
            //        }, new List<Note> {
            //            new Note("Some Note", "This is a note. Neat aye?"),
            //            new Note("Another Note", "Heres another note. Less neat I'd say.")
            //        }),
            //        new Course("Software 1", CourseStatus.InProgress, "Karth Onasi", "(801)-999-9999", "karth@gmail.com", 6, DateTime.Now, DateTime.Now.AddDays(10), new List<Assessment> {
            //            new Assessment("Some Test", AssessmentType.Objective, false, DateTime.Now, DateTime.Now.AddDays(10)),
            //            new Assessment("Another Test", AssessmentType.Performance, false, DateTime.Now, DateTime.Now.AddDays(10))
            //        }, new List<Note> {
            //            new Note("Some Note", "This is a note. Neat aye?"),
            //            new Note("Another Note", "Heres another note. Less neat I'd say.")
            //        }),
            //        new Course("Software 1", CourseStatus.InProgress, "Karth Onasi", "(801)-999-9999", "karth@gmail.com", 6, DateTime.Now, DateTime.Now.AddDays(10), new List<Assessment> {
            //            new Assessment("Some Test", AssessmentType.Objective, false, DateTime.Now, DateTime.Now.AddDays(10)),
            //            new Assessment("Another Test", AssessmentType.Performance, false, DateTime.Now, DateTime.Now.AddDays(10))
            //        }, new List<Note> {
            //            new Note("Some Note", "This is a note. Neat aye?"),
            //            new Note("Another Note", "Heres another note. Less neat I'd say.")
            //        })
            //    })),
            //    new TermGroup(new Term("Term 3", true, DateTime.Now, DateTime.Now.AddDays(10), new List<Course> {
            //        new Course("Software 1", CourseStatus.InProgress, "Karth Onasi", "(801)-999-9999", "karth@gmail.com", 6, DateTime.Now, DateTime.Now.AddDays(10), new List<Assessment> {
            //            new Assessment("Some Test", AssessmentType.Objective, false, DateTime.Now, DateTime.Now.AddDays(10)),
            //            new Assessment("Another Test", AssessmentType.Performance, false, DateTime.Now, DateTime.Now.AddDays(10))
            //        }, new List<Note> {
            //            new Note("Some Note", "This is a note. Neat aye?"),
            //            new Note("Another Note", "Heres another note. Less neat I'd say.")
            //        }),
            //        new Course("Software 1", CourseStatus.InProgress, "Karth Onasi", "(801)-999-9999", "karth@gmail.com", 6, DateTime.Now, DateTime.Now.AddDays(10), new List<Assessment> {
            //            new Assessment("Some Test", AssessmentType.Objective, false, DateTime.Now, DateTime.Now.AddDays(10)),
            //            new Assessment("Another Test", AssessmentType.Performance, false, DateTime.Now, DateTime.Now.AddDays(10))
            //        }, new List<Note> {
            //            new Note("Some Note", "This is a note. Neat aye?"),
            //            new Note("Another Note", "Heres another note. Less neat I'd say.")
            //        }),
            //        new Course("Software 1", CourseStatus.InProgress, "Karth Onasi", "(801)-999-9999", "karth@gmail.com", 6, DateTime.Now, DateTime.Now.AddDays(10), new List<Assessment> {
            //            new Assessment("Some Test", AssessmentType.Objective, false, DateTime.Now, DateTime.Now.AddDays(10)),
            //            new Assessment("Another Test", AssessmentType.Performance, false, DateTime.Now, DateTime.Now.AddDays(10))
            //        }, new List<Note> {
            //            new Note("Some Note", "This is a note. Neat aye?"),
            //            new Note("Another Note", "Heres another note. Less neat I'd say.")
            //        }),
            //        new Course("Software 1", CourseStatus.InProgress, "Karth Onasi", "(801)-999-9999", "karth@gmail.com", 6, DateTime.Now, DateTime.Now.AddDays(10), new List<Assessment> {
            //            new Assessment("Some Test", AssessmentType.Objective, false, DateTime.Now, DateTime.Now.AddDays(10)),
            //            new Assessment("Another Test", AssessmentType.Performance, false, DateTime.Now, DateTime.Now.AddDays(10))
            //        }, new List<Note> {
            //            new Note("Some Note", "This is a note. Neat aye?"),
            //            new Note("Another Note", "Heres another note. Less neat I'd say.")
            //        }),
            //        new Course("Software 1", CourseStatus.InProgress, "Karth Onasi", "(801)-999-9999", "karth@gmail.com", 6, DateTime.Now, DateTime.Now.AddDays(10), new List<Assessment> {
            //            new Assessment("Some Test", AssessmentType.Objective, false, DateTime.Now, DateTime.Now.AddDays(10)),
            //            new Assessment("Another Test", AssessmentType.Performance, false, DateTime.Now, DateTime.Now.AddDays(10))
            //        }, new List<Note> {
            //            new Note("Some Note", "This is a note. Neat aye?"),
            //            new Note("Another Note", "Heres another note. Less neat I'd say.")
            //        }),
            //        new Course("Software 1", CourseStatus.InProgress, "Karth Onasi", "(801)-999-9999", "karth@gmail.com", 6, DateTime.Now, DateTime.Now.AddDays(10), new List<Assessment> {
            //            new Assessment("Some Test", AssessmentType.Objective, false, DateTime.Now, DateTime.Now.AddDays(10)),
            //            new Assessment("Another Test", AssessmentType.Performance, false, DateTime.Now, DateTime.Now.AddDays(10))
            //        }, new List<Note> {
            //            new Note("Some Note", "This is a note. Neat aye?"),
            //            new Note("Another Note", "Heres another note. Less neat I'd say.")
            //        })
            //    })),
            //    new TermGroup(new Term("Term 4", true, DateTime.Now, DateTime.Now.AddDays(10), new List<Course> {
            //        new Course("Software 1", CourseStatus.InProgress, "Karth Onasi", "(801)-999-9999", "karth@gmail.com", 6, DateTime.Now, DateTime.Now.AddDays(10), new List<Assessment> {
            //            new Assessment("Some Test", AssessmentType.Objective, false, DateTime.Now, DateTime.Now.AddDays(10)),
            //            new Assessment("Another Test", AssessmentType.Performance, false, DateTime.Now, DateTime.Now.AddDays(10))
            //        }, new List<Note> {
            //            new Note("Some Note", "This is a note. Neat aye?"),
            //            new Note("Another Note", "Heres another note. Less neat I'd say.")
            //        }),
            //        new Course("Software 1", CourseStatus.InProgress, "Karth Onasi", "(801)-999-9999", "karth@gmail.com", 6, DateTime.Now, DateTime.Now.AddDays(10), new List<Assessment> {
            //            new Assessment("Some Test", AssessmentType.Objective, false, DateTime.Now, DateTime.Now.AddDays(10)),
            //            new Assessment("Another Test", AssessmentType.Performance, false, DateTime.Now, DateTime.Now.AddDays(10))
            //        }, new List<Note> {
            //            new Note("Some Note", "This is a note. Neat aye?"),
            //            new Note("Another Note", "Heres another note. Less neat I'd say.")
            //        }),
            //        new Course("Software 1", CourseStatus.InProgress, "Karth Onasi", "(801)-999-9999", "karth@gmail.com", 6, DateTime.Now, DateTime.Now.AddDays(10), new List<Assessment> {
            //            new Assessment("Some Test", AssessmentType.Objective, false, DateTime.Now, DateTime.Now.AddDays(10)),
            //            new Assessment("Another Test", AssessmentType.Performance, false, DateTime.Now, DateTime.Now.AddDays(10))
            //        }, new List<Note> {
            //            new Note("Some Note", "This is a note. Neat aye?"),
            //            new Note("Another Note", "Heres another note. Less neat I'd say.")
            //        }),
            //        new Course("Software 1", CourseStatus.InProgress, "Karth Onasi", "(801)-999-9999", "karth@gmail.com", 6, DateTime.Now, DateTime.Now.AddDays(10), new List<Assessment> {
            //            new Assessment("Some Test", AssessmentType.Objective, false, DateTime.Now, DateTime.Now.AddDays(10)),
            //            new Assessment("Another Test", AssessmentType.Performance, false, DateTime.Now, DateTime.Now.AddDays(10))
            //        }, new List<Note> {
            //            new Note("Some Note", "This is a note. Neat aye?"),
            //            new Note("Another Note", "Heres another note. Less neat I'd say.")
            //        }),
            //        new Course("Software 1", CourseStatus.InProgress, "Karth Onasi", "(801)-999-9999", "karth@gmail.com", 6, DateTime.Now, DateTime.Now.AddDays(10), new List<Assessment> {
            //            new Assessment("Some Test", AssessmentType.Objective, false, DateTime.Now, DateTime.Now.AddDays(10)),
            //            new Assessment("Another Test", AssessmentType.Performance, false, DateTime.Now, DateTime.Now.AddDays(10))
            //        }, new List<Note> {
            //            new Note("Some Note", "This is a note. Neat aye?"),
            //            new Note("Another Note", "Heres another note. Less neat I'd say.")
            //        }),
            //        new Course("Software 1", CourseStatus.InProgress, "Karth Onasi", "(801)-999-9999", "karth@gmail.com", 6, DateTime.Now, DateTime.Now.AddDays(10), new List<Assessment> {
            //            new Assessment("Some Test", AssessmentType.Objective, false, DateTime.Now, DateTime.Now.AddDays(10)),
            //            new Assessment("Another Test", AssessmentType.Performance, false, DateTime.Now, DateTime.Now.AddDays(10))
            //        }, new List<Note> {
            //            new Note("Some Note", "This is a note. Neat aye?"),
            //            new Note("Another Note", "Heres another note. Less neat I'd say.")
            //        })
            //    })),
            //    new TermGroup(new Term("Test Term Longer", true, DateTime.Now, DateTime.Now.AddDays(10), new List<Course> {
            //        new Course("Software 1", CourseStatus.InProgress, "Karth Onasi", "(801)-999-9999", "karth@gmail.com", 6, DateTime.Now, DateTime.Now.AddDays(10), new List<Assessment> {
            //            new Assessment("Some Test", AssessmentType.Objective, false, DateTime.Now, DateTime.Now.AddDays(10)),
            //            new Assessment("Another Test", AssessmentType.Performance, false, DateTime.Now, DateTime.Now.AddDays(10))
            //        }, new List<Note> {
            //            new Note("Some Note", "This is a note. Neat aye?"),
            //            new Note("Another Note", "Heres another note. Less neat I'd say.")
            //        }),
            //        new Course("Software 1", CourseStatus.InProgress, "Karth Onasi", "(801)-999-9999", "karth@gmail.com", 6, DateTime.Now, DateTime.Now.AddDays(10), new List<Assessment> {
            //            new Assessment("Some Test", AssessmentType.Objective, false, DateTime.Now, DateTime.Now.AddDays(10)),
            //            new Assessment("Another Test", AssessmentType.Performance, false, DateTime.Now, DateTime.Now.AddDays(10))
            //        }, new List<Note> {
            //            new Note("Some Note", "This is a note. Neat aye?"),
            //            new Note("Another Note", "Heres another note. Less neat I'd say.")
            //        }),
            //        new Course("Software 1", CourseStatus.InProgress, "Karth Onasi", "(801)-999-9999", "karth@gmail.com", 6, DateTime.Now, DateTime.Now.AddDays(10), new List<Assessment> {
            //            new Assessment("Some Test", AssessmentType.Objective, false, DateTime.Now, DateTime.Now.AddDays(10)),
            //            new Assessment("Another Test", AssessmentType.Performance, false, DateTime.Now, DateTime.Now.AddDays(10))
            //        }, new List<Note> {
            //            new Note("Some Note", "This is a note. Neat aye?"),
            //            new Note("Another Note", "Heres another note. Less neat I'd say.")
            //        }),
            //        new Course("Software 1", CourseStatus.InProgress, "Karth Onasi", "(801)-999-9999", "karth@gmail.com", 6, DateTime.Now, DateTime.Now.AddDays(10), new List<Assessment> {
            //            new Assessment("Some Test", AssessmentType.Objective, false, DateTime.Now, DateTime.Now.AddDays(10)),
            //            new Assessment("Another Test", AssessmentType.Performance, false, DateTime.Now, DateTime.Now.AddDays(10))
            //        }, new List<Note> {
            //            new Note("Some Note", "This is a note. Neat aye?"),
            //            new Note("Another Note", "Heres another note. Less neat I'd say.")
            //        }),
            //        new Course("Software 1", CourseStatus.InProgress, "Karth Onasi", "(801)-999-9999", "karth@gmail.com", 6, DateTime.Now, DateTime.Now.AddDays(10), new List<Assessment> {
            //            new Assessment("Some Test", AssessmentType.Objective, false, DateTime.Now, DateTime.Now.AddDays(10)),
            //            new Assessment("Another Test", AssessmentType.Performance, false, DateTime.Now, DateTime.Now.AddDays(10))
            //        }, new List<Note> {
            //            new Note("Some Note", "This is a note. Neat aye?"),
            //            new Note("Another Note", "Heres another note. Less neat I'd say.")
            //        }),
            //        new Course("Software 1", CourseStatus.InProgress, "Karth Onasi", "(801)-999-9999", "karth@gmail.com", 6, DateTime.Now, DateTime.Now.AddDays(10), new List<Assessment> {
            //            new Assessment("Some Test", AssessmentType.Objective, false, DateTime.Now, DateTime.Now.AddDays(10)),
            //            new Assessment("Another Test", AssessmentType.Performance, false, DateTime.Now, DateTime.Now.AddDays(10))
            //        }, new List<Note> {
            //            new Note("Some Note", "This is a note. Neat aye?"),
            //            new Note("Another Note", "Heres another note. Less neat I'd say.")
            //        })
            //    })),
            //    new TermGroup(new Term("Term 6", true, DateTime.Now, DateTime.Now.AddDays(10), new List<Course> {
            //        new Course("Software 1", CourseStatus.InProgress, "Karth Onasi", "(801)-999-9999", "karth@gmail.com", 6, DateTime.Now, DateTime.Now.AddDays(10), new List<Assessment> {
            //            new Assessment("Some Test", AssessmentType.Objective, false, DateTime.Now, DateTime.Now.AddDays(10)),
            //            new Assessment("Another Test", AssessmentType.Performance, false, DateTime.Now, DateTime.Now.AddDays(10))
            //        }, new List<Note> {
            //            new Note("Some Note", "This is a note. Neat aye?"),
            //            new Note("Another Note", "Heres another note. Less neat I'd say.")
            //        }),
            //        new Course("Software 1", CourseStatus.InProgress, "Karth Onasi", "(801)-999-9999", "karth@gmail.com", 6, DateTime.Now, DateTime.Now.AddDays(10), new List<Assessment> {
            //            new Assessment("Some Test", AssessmentType.Objective, false, DateTime.Now, DateTime.Now.AddDays(10)),
            //            new Assessment("Another Test", AssessmentType.Performance, false, DateTime.Now, DateTime.Now.AddDays(10))
            //        }, new List<Note> {
            //            new Note("Some Note", "This is a note. Neat aye?"),
            //            new Note("Another Note", "Heres another note. Less neat I'd say.")
            //        }),
            //        new Course("Software 1", CourseStatus.InProgress, "Karth Onasi", "(801)-999-9999", "karth@gmail.com", 6, DateTime.Now, DateTime.Now.AddDays(10), new List<Assessment> {
            //            new Assessment("Some Test", AssessmentType.Objective, false, DateTime.Now, DateTime.Now.AddDays(10)),
            //            new Assessment("Another Test", AssessmentType.Performance, false, DateTime.Now, DateTime.Now.AddDays(10))
            //        }, new List<Note> {
            //            new Note("Some Note", "This is a note. Neat aye?"),
            //            new Note("Another Note", "Heres another note. Less neat I'd say.")
            //        }),
            //        new Course("Software 1", CourseStatus.InProgress, "Karth Onasi", "(801)-999-9999", "karth@gmail.com", 6, DateTime.Now, DateTime.Now.AddDays(10), new List<Assessment> {
            //            new Assessment("Some Test", AssessmentType.Objective, false, DateTime.Now, DateTime.Now.AddDays(10)),
            //            new Assessment("Another Test", AssessmentType.Performance, false, DateTime.Now, DateTime.Now.AddDays(10))
            //        }, new List<Note> {
            //            new Note("Some Note", "This is a note. Neat aye?"),
            //            new Note("Another Note", "Heres another note. Less neat I'd say.")
            //        }),
            //        new Course("Software 1", CourseStatus.InProgress, "Karth Onasi", "(801)-999-9999", "karth@gmail.com", 6, DateTime.Now, DateTime.Now.AddDays(10), new List<Assessment> {
            //            new Assessment("Some Test", AssessmentType.Objective, false, DateTime.Now, DateTime.Now.AddDays(10)),
            //            new Assessment("Another Test", AssessmentType.Performance, false, DateTime.Now, DateTime.Now.AddDays(10))
            //        }, new List<Note> {
            //            new Note("Some Note", "This is a note. Neat aye?"),
            //            new Note("Another Note", "Heres another note. Less neat I'd say.")
            //        }),
            //        new Course("Software 1", CourseStatus.InProgress, "Karth Onasi", "(801)-999-9999", "karth@gmail.com", 6, DateTime.Now, DateTime.Now.AddDays(10), new List<Assessment> {
            //            new Assessment("Some Test", AssessmentType.Objective, false, DateTime.Now, DateTime.Now.AddDays(10)),
            //            new Assessment("Another Test", AssessmentType.Performance, false, DateTime.Now, DateTime.Now.AddDays(10))
            //        }, new List<Note> {
            //            new Note("Some Note", "This is a note. Neat aye?"),
            //            new Note("Another Note", "Heres another note. Less neat I'd say.")
            //        })
            //    }))
            //};
        }
    }
}
