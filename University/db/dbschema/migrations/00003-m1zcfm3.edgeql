CREATE MIGRATION m1zcfm3eehagzhowglc4onvhu4qkrrhrulsfaizziutey3f45ewsxa
    ONTO m1g36jjrzc3vjkdincfdj6iyd7r35jgkutv6x4dklpw2rn7fb6ruhq
{
  CREATE TYPE default::Account {
      CREATE REQUIRED PROPERTY password: std::str;
      CREATE REQUIRED PROPERTY username: std::str {
          CREATE CONSTRAINT std::exclusive;
      };
  };
};
