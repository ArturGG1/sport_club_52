namespace sport_club_52;

public class Tariff
{
    public uint Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public uint TrainerId { get; set; } // внешний ключ на тренера
    public Trainer? Trainer { get; set; }
    public byte Visits { get; set; }
    public uint Price { get; set; } 
}
public class Client
{
    public uint Id { get; set; }
    public string Name { get; set; }
    public DateOnly Birthday { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public uint MembershipId { get; set; } // внешний ключ на абонемент
    public Membership Membership { get; set; } // абонемент
    public uint BoxId { get; set; } // номер шкафа
}
public class Membership
{
    public uint Id { get; set; }
    public uint TariffId { get; set; } // внешний ключ на тариф
    public Tariff Tariff { get; set; }
    public uint PaymentId { get; set; } // внешний ключ на оплату
    public Payment Payment { get; set; }
    public byte VisitsLeft { get; set; } // кол-во оставшихся занятий
    public bool Suspended { get; set; } // приостановлен ли абонемент
}
public class Payment
{
    public uint Id { get; set; }
    public uint Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public uint CashierId { get; set; } // внешний ключ на кассира
    public Cashier Cashier { get; set; }
}
public abstract class Worker
{
    public uint Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
}
public class Trainer : Worker
{
    
}
public class Cashier : Worker
{
    public List<Payment> Payments { get; set; }
}