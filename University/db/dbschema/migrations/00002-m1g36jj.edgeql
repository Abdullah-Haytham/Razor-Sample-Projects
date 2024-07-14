CREATE MIGRATION m1g36jjrzc3vjkdincfdj6iyd7r35jgkutv6x4dklpw2rn7fb6ruhq
    ONTO m1an7jxemdf2j5xypxsnxj5r7alshfvucu2ok6gj7ngjornjlduaua
{
  ALTER TYPE default::Student {
      ALTER PROPERTY Studentid {
          RENAME TO student_id;
      };
  };
};
