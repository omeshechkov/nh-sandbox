using FluentNHibernate.Mapping;

namespace Sandbox.Nh;

public class User
{
    public virtual long Id { get; set; }

    public virtual string Name { get; set; } = null!;

    public virtual string Surname { get; set; } = null!;

    public virtual string? MiddleName { get; set; }

    public virtual IList<UserAccount> Accounts { get; set; } = new List<UserAccount>();

    public virtual void AddAccount(string currency)
    {
        Accounts.Add(new UserAccount
        {
            User = this,
            Currency = currency,
            Balance = 0
        });
    }
    
    public virtual void RemoveAccount(string currency)
    {
        var account = Accounts.FirstOrDefault(x => x.Currency == currency);
        if (account is null)
            return;

        Accounts.Remove(account);
    }

    [UsedImplicitly]
    public class NhMap : ClassMap<User>
    {
        public NhMap()
        {
            Schema("public");
            Table("users");

            Id(x => x.Id, column: "id")
                .GeneratedBy.Sequence("users_id_seq")
                .UnsavedValue(0L);

            Map(x => x.Name, "name");

            Map(x => x.Surname, "surname");

            Map(x => x.MiddleName, "middle_name");

            HasMany(x => x.Accounts)
                .Inverse()
                .Cascade.AllDeleteOrphan();
        }
    }
}