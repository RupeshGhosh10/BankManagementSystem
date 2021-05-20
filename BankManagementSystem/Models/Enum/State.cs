using System.ComponentModel.DataAnnotations;

namespace BankManagementSystem.Models.Enum
{
    public enum State
    {
        [Display(Name = "Andhra Pradesh")]
        AndhraPradesh,
        [Display(Name = "Arunachal Pradesh")]
        ArunachalPradesh,
        Assam,
        Bihar,
        Chhattisgarh,
        Goa,
        Gujrat,
        Haryana,
        [Display(Name = "Himachal Pradesh")]
        HimachalPradesh,
        Jharkhand,
        Karnataka,
        Kerala,
        [Display(Name = "Madhya Pradesh")]
        MadhyaPradesh,
        Maharashtra,
        Manipur,
        Meghalaya,
        Mizoram,
        Nagaland,
        Odisha,
        Punjab,
        Rajashtan,
        Sikkim,
        [Display(Name = "Tamil Nadu")]
        TamilNadu,
        Telangana,
        Tripura,
        [Display(Name = "Uttar Pradesh")]
        UttarPradesh,
        Uttarakhand,
        [Display(Name = "West Bengal")]
        WestBengal
    }
}
