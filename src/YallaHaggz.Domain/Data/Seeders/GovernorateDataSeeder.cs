using Microsoft.EntityFrameworkCore;
using YallaHaggz.Domain.Abstractions;
using YallaHaggz.Domain.Entities.Locations;

namespace YallaHaggz.Domain.Data.Seeders;

public class GovernorateDataSeeder(YallaHaggzDbContext dbContext) : IDomainDataSeeder
{
    public async Task SeedEssentialDataAsync()
    {
        if (!await dbContext.Governorates.AnyAsync())
        {
            await dbContext.Governorates.AddRangeAsync(Governorates);
            await dbContext.SaveChangesAsync();
        }
    }

    private static IReadOnlyCollection<Governorate> Governorates =>
        [
            new Governorate { NameAr = "القاهرة", NameEn = "Cairo", Cities = [
                new() { NameAr = "15 مايو", NameEn = "15 May" },
                new() { NameAr = "الازبكية", NameEn = "Al Azbakeyah" },
                new() { NameAr = "البساتين", NameEn = "Al Basatin" },
                new() { NameAr = "التبين", NameEn = "Tebin" },
                new() { NameAr = "الخليفة", NameEn = "El-Khalifa" },
                new() { NameAr = "الدراسة", NameEn = "El darrasa" },
                new() { NameAr = "الدرب الاحمر", NameEn = "Aldarb Alahmar" },
                new() { NameAr = "الزاوية الحمراء", NameEn = "Zawya al-Hamra" },
                new() { NameAr = "الزيتون", NameEn = "El-Zaytoun" },
                new() { NameAr = "الساحل", NameEn = "Sahel" },
                new() { NameAr = "السلام", NameEn = "El Salam" },
                new() { NameAr = "السيدة زينب", NameEn = "Sayeda Zeinab" },
                new() { NameAr = "الشرابية", NameEn = "El Sharabeya" },
                new() { NameAr = "مدينة الشروق", NameEn = "Shorouk" },
                new() { NameAr = "الظاهر", NameEn = "El Daher" },
                new() { NameAr = "العتبة", NameEn = "Ataba" },
                new() { NameAr = "القاهرة الجديدة", NameEn = "New Cairo" },
                new() { NameAr = "المرج", NameEn = "El Marg" },
                new() { NameAr = "عزبة النخل", NameEn = "Ezbet el Nakhl" },
                new() { NameAr = "المطرية", NameEn = "Matareya" },
                new() { NameAr = "المعادى", NameEn = "Maadi" },
                new() { NameAr = "المعصرة", NameEn = "Maasara" },
                new() { NameAr = "المقطم", NameEn = "Mokattam" },
                new() { NameAr = "المنيل", NameEn = "Manyal" },
                new() { NameAr = "الموسكى", NameEn = "Mosky" },
                new() { NameAr = "النزهة", NameEn = "Nozha" },
                new() { NameAr = "الوايلى", NameEn = "Waily" },
                new() { NameAr = "باب الشعرية", NameEn = "Bab al-Shereia" },
                new() { NameAr = "بولاق", NameEn = "Bolaq" },
                new() { NameAr = "جاردن سيتى", NameEn = "Garden City" },
                new() { NameAr = "حدائق القبة", NameEn = "Hadayek El-Kobba" },
                new() { NameAr = "حلوان", NameEn = "Helwan" },
                new() { NameAr = "دار السلام", NameEn = "Dar Al Salam" },
                new() { NameAr = "شبرا", NameEn = "Shubra" },
                new() { NameAr = "طره", NameEn = "Tura" },
                new() { NameAr = "عابدين", NameEn = "Abdeen" },
                new() { NameAr = "عباسية", NameEn = "Abaseya" },
                new() { NameAr = "عين شمس", NameEn = "Ain Shams" },
                new() { NameAr = "مدينة نصر", NameEn = "Nasr City" },
                new() { NameAr = "مصر الجديدة", NameEn = "New Heliopolis" },
                new() { NameAr = "مصر القديمة", NameEn = "Masr Al Qadima" },
                new() { NameAr = "منشية ناصر", NameEn = "Mansheya Nasir" },
                new() { NameAr = "مدينة بدر", NameEn = "Badr City" },
                new() { NameAr = "مدينة العبور", NameEn = "Obour City" },
                new() { NameAr = "وسط البلد", NameEn = "Cairo Downtown" },
                new() { NameAr = "الزمالك", NameEn = "Zamalek" },
                new() { NameAr = "قصر النيل", NameEn = "Kasr El Nile" },
                new() { NameAr = "الرحاب", NameEn = "Rehab" },
                new() { NameAr = "القطامية", NameEn = "Katameya" },
                new() { NameAr = "مدينتي", NameEn = "Madinty" }
            ] },
            new Governorate { NameAr = "الإسكندرية", NameEn = "Alexandria", Cities = [
                new() { NameAr = "العجمي", NameEn = "Agamy" },
                new() { NameAr = "سموحة", NameEn = "Smouha" },
                new() { NameAr = "المنشية", NameEn = "Mansheya" },
                new() { NameAr = "سيدي بشر", NameEn = "Sidi Bishr" },
                new() { NameAr = "محرم بك", NameEn = "Moharam Bek" },
                new() { NameAr = "العطارين", NameEn = "Attarin" },
                new() { NameAr = "المنتزه", NameEn = "Montaza" },
                new() { NameAr = "المعمورة", NameEn = "Maamoura" },
                new() { NameAr = "المندرة", NameEn = "Mandara" },
                new() { NameAr = "الشاطبي", NameEn = "Shatby" },
                new() { NameAr = "اللبان", NameEn = "Labban" },
                new() { NameAr = "الرمل", NameEn = "Raml" },
                new() { NameAr = "العصافرة", NameEn = "Asafra" },
                new() { NameAr = "العامرية", NameEn = "Ameria" }
            ] },
           new Governorate { NameAr = "الجيزة", NameEn = "Giza", Cities = [
                new() { NameAr = "الجيزة", NameEn = "Giza" },
                new() { NameAr = "السادس من أكتوبر", NameEn = "Sixth of October" },
                new() { NameAr = "الشيخ زايد", NameEn = "Sheikh Zayed" },
                new() { NameAr = "الحوامدية", NameEn = "Hawamdiyah" },
                new() { NameAr = "البدرشين", NameEn = "Al Badrasheen" },
                new() { NameAr = "الصف", NameEn = "Saf" },
                new() { NameAr = "أطفيح", NameEn = "Atfih" },
                new() { NameAr = "العياط", NameEn = "Al Ayat" },
                new() { NameAr = "الباويطي", NameEn = "Al-Bawaiti" },
                new() { NameAr = "منشأة القناطر", NameEn = "Manshiyet Al Qanater" },
                new() { NameAr = "أوسيم", NameEn = "Oaseem" },
                new() { NameAr = "كرداسة", NameEn = "Kerdasa" },
                new() { NameAr = "أبو النمرس", NameEn = "Abu Nomros" },
                new() { NameAr = "كفر غطاطي", NameEn = "Kafr Ghati" },
                new() { NameAr = "منشأة البكاري", NameEn = "Manshiyet Al Bakari" },
                new() { NameAr = "الدقى", NameEn = "Dokki" },
                new() { NameAr = "العجوزة", NameEn = "Agouza" },
                new() { NameAr = "الهرم", NameEn = "Haram" },
                new() { NameAr = "الوراق", NameEn = "Warraq" },
                new() { NameAr = "امبابة", NameEn = "Imbaba" },
                new() { NameAr = "بولاق الدكرور", NameEn = "Boulaq Dakrour" },
                new() { NameAr = "الواحات البحرية", NameEn = "Al Wahat Al Baharia" },
                new() { NameAr = "العمرانية", NameEn = "Omraneya" },
                new() { NameAr = "المنيب", NameEn = "Moneeb" },
                new() { NameAr = "بين السرايات", NameEn = "Bin Alsarayat" },
                new() { NameAr = "الكيت كات", NameEn = "Kit Kat" },
                new() { NameAr = "المهندسين", NameEn = "Mohandessin" },
                new() { NameAr = "فيصل", NameEn = "Faisal" },
                new() { NameAr = "أبو رواش", NameEn = "Abu Rawash" },
                new() { NameAr = "حدائق الأهرام", NameEn = "Hadayek Alahram" },
                new() { NameAr = "الحرانية", NameEn = "Haraneya" },
                new() { NameAr = "حدائق اكتوبر", NameEn = "Hadayek October" },
                new() { NameAr = "صفط اللبن", NameEn = "Saft Allaban" },
                new() { NameAr = "القرية الذكية", NameEn = "Smart Village" },
                new() { NameAr = "ارض اللواء", NameEn = "Ard Ellwaa" }
                ] },
        new Governorate { NameAr = " الشرقية",NameEn = "Sharqia", Cities = [
                new() { NameAr = "الزقازيق", NameEn = "Zagazig" },
                new() { NameAr = "بلبيس", NameEn = "Belbeis" },
                new() { NameAr = "منيا القمح", NameEn = "Minya Al-Qamh" },
                new() { NameAr = "ههيا", NameEn = "Hehia" },
                new() { NameAr = "أبو حماد", NameEn = "Abu Hammad" },
                new() { NameAr = "القنايات", NameEn = "Qenaiat" },
                new() { NameAr = "أبو كبير", NameEn = "Abu Kabir" },
                new() { NameAr = "فاقوس", NameEn = "Faqous" },
                new() { NameAr = "الصالحية الجديدة", NameEn = "El Salheya El Gedida" },
                new() { NameAr = "الإبراهيمية", NameEn = "El Ibrahimia" },
                new() { NameAr = "ديرب نجم", NameEn = "Deirb Negm" },
        ] },
        new Governorate { NameAr = "القليوبية", NameEn = "Qalyubia", Cities = [
                new() { NameAr = "بنها", NameEn = "Banha" },
                new() { NameAr = "قليوب", NameEn = "Qalyub" },
                new() { NameAr = "شبرا الخيمة", NameEn = "Shubra El Kheima" },
                new() { NameAr = "الخانكة", NameEn = "El Khanka" },
                new() { NameAr = "كفر شكر", NameEn = "Kafr Shukr" },
                new() { NameAr = "طوخ", NameEn = "Tukh" },
                new() { NameAr = "القناطر الخيرية", NameEn = "El Qanater El Khayreya" }
            ] },

         new Governorate { NameAr = "الفيوم", NameEn = "Fayoum", Cities = [
                new() { NameAr = "الفيوم", NameEn = "Fayoum" },
                new() { NameAr = "إطسا", NameEn = "Itsa" },
                new() { NameAr = "طامية", NameEn = "Tamiya" },
                new() { NameAr = "سنورس", NameEn = "Sennuris" },
                new() { NameAr = "يوسف الصديق", NameEn = "Yusuf El Sadiq" },
                new() { NameAr = "الفيوم الجديدة", NameEn = "New Fayoum" }
         ] },

         new Governorate { NameAr = "كفر الشيخ", NameEn = "Kafr El Sheikh", Cities = [
                new() { NameAr = "كفر الشيخ", NameEn = "Kafr El Sheikh" },
                new() { NameAr = "دسوق", NameEn = "Desouk" },
                new() { NameAr = "بلطيم", NameEn = "Baltim" },
                new() { NameAr = "فوه", NameEn = "Fuwwah" },
                new() { NameAr = "سيدي سالم", NameEn = "Sidi Salem" }
        ] },

        ];
}