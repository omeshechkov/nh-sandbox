using FluentNHibernate.Mapping;

namespace Sandbox.Nh;

public class UserAccount
{
    public virtual long Id { get; set; }
    
    public virtual User User { get; set; }

    public virtual string Currency { get; set; }

    public virtual decimal Balance { get; set; }

    [UsedImplicitly]
    public class NhMap : ClassMap<UserAccount>
    {
        public NhMap()
        {
            Schema("public");
            Table("user_accounts");
            
            Id(x => x.Id, column: "id")
                .GeneratedBy.Sequence("user_accounts_id_seq")
                .UnsavedValue(0L);

            References(x => x.User, "user_id");
            
            Map(x => x.Currency, "currency");
            
            Map(x => x.Balance, "balance");
        }
    }
}