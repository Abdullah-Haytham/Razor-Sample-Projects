CREATE MIGRATION m1an7jxemdf2j5xypxsnxj5r7alshfvucu2ok6gj7ngjornjlduaua
    ONTO initial
{
  CREATE TYPE default::Course {
      CREATE REQUIRED PROPERTY code: std::str;
      CREATE REQUIRED PROPERTY credit: std::int64;
      CREATE REQUIRED PROPERTY name: std::str;
  };
  CREATE TYPE default::Department {
      CREATE MULTI LINK courses: default::Course;
      CREATE REQUIRED PROPERTY code: std::str;
      CREATE REQUIRED PROPERTY name: std::str;
  };
  ALTER TYPE default::Course {
      CREATE LINK department: default::Department;
  };
  CREATE TYPE default::Student {
      CREATE MULTI LINK courses: default::Course;
      CREATE LINK department: default::Department;
      CREATE REQUIRED PROPERTY Studentid: std::str {
          CREATE CONSTRAINT std::exclusive;
      };
      CREATE REQUIRED PROPERTY age: std::int64;
      CREATE REQUIRED PROPERTY name: std::str;
  };
  ALTER TYPE default::Course {
      CREATE MULTI LINK students: default::Student;
  };
  ALTER TYPE default::Department {
      CREATE MULTI LINK students: default::Student;
  };
};
