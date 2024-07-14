module default {
    type Student{
        required student_id: str{
            constraint exclusive;
        }
        required name: str;
        required age: int64;
        multi link courses: Course;
        link department: Department;
    }

    type Course{
        required name: str;
        required code: str;
        required credit: int64;
        multi link students: Student;
        link department: Department;
    }

    type Department{
        required name: str;
        required code: str;
        multi link courses: Course;
        multi link students: Student;
    }

    type Account{
        required username: str{
            constraint exclusive
        }
        required password: str;
    }
}
