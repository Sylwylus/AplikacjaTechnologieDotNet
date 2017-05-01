
            using System.Collections.Generic;
using Domain.Model;

namespace Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.CrudContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Data.CrudContext";
        }

        protected override void Seed(Data.CrudContext context)
        {

            var roles = new List<CustomRole>
            {
                new CustomRole {Name = "Moderator"},
                new CustomRole {Name = "Administrator"}

            };

            roles.ForEach(s => context.Roles.Add(s));
            context.SaveChanges();

            var categorys = new List<Category>
            {
            new Category{Name = "Adventure" },
            new Category{Name = "Card game" },
            new Category{Name = "Cooperative" },
            new Category{Name = "Dice" },
            new Category{Name = "Economic" },
            new Category{Name = "Family" },
            new Category{Name = "Party" },
            new Category{Name = "Strategic" },
            
                      
            
            };


            categorys.ForEach(s => context.Categorys.Add(s));
            context.SaveChanges();


            var users = new List<User>
            {
                new User{FirstName = "Barbara",LastName = "Potoczek",Moderator = false,Administrator = false,UserName = "Palindrom",Email = "lok@pal.il",DateOfBirth = DateTime.Parse("1990-01-02"),PasswordHash = "ABCnsHLoKDeel7hY19/kt3p1rbAtdVbG+S/6DfcN34S9nP0tjPCepID/OwqxSa1Isw==",SecurityStamp = "51c73935-46b7-401e-bf66-b44b5087c757",RegisterDate = DateTime.Parse("2015-01-02")},
                new User{FirstName = "Kajko",LastName = "Kokoszek",Moderator = true,Administrator =true,UserName = "Superbohater",Email = "kokoszek@gmail.com",DateOfBirth = DateTime.Parse("1995-01-10"),PasswordHash = "AF5f+aep14wz3MvERr7spw0D80AXulFXSE1/bTgURp8/+1sP4Qc7rPPMp4uQU4MJaA==",SecurityStamp = "8b2527c8-00ce-4162-bc35-335c53116730",RegisterDate = DateTime.Parse("2015-01-13")},
                new User{FirstName = "Baltazar",LastName = "Gabka",Moderator = true,Administrator = false,UserName = "Minion",Email = "balterek@gmail.com",DateOfBirth = DateTime.Parse("1980-09-16"),PasswordHash = "AGGk0tsCLoeKlfj0157PuO+FDW+LKg89NDuEOaR1ss0Rp/J7h8LJyHFeV09eP16Gyw==",SecurityStamp = "c874da94-8a9f-4a0d-a8d6-8ad220c595e2",RegisterDate = DateTime.Parse("2014-03-02")},
          };

            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();


            var games = new List<Game>
            {
            new Game{Name = "Talisman", CategoryId = 1, Description = "Wyprawa do krainy smoków i magii! W tej pe³nej przygód grze wyruszysz na niebezpieczn¹ wyprawê po najwiêkszy skarb, legendarn¹ Koronê W³adzy. Wcielisz siê w wojownika, kap³ana, czarnoksiê¿nika lub jednego z pozosta³ych jedenastu bohaterów w³adaj¹cych magi¹ lub mieczem.", Publisher = "Galakta", MaxNumberOfPlayers = 6, MinNumberOfPlayers = 2, PlayingTime = 150, PublishedDate = DateTime.Parse("2015-01-14"), SuggestedAge = 12, Accepted=true},
            new Game{Name = "Wikingowie", CategoryId = 1, Description = "Gracze wcielaj¹ siê w Jarlów wikingów, którzy walcz¹ o w³adzê nad Pó³noc¹ i koronê Konunga. W³adzê zdobêdzie ten, który jako pierwszy z³upi wszystkie wsie i przywiezie z nich córki thanów do swojego portu, jako symbol uznania jego praw do korony. ", Publisher = "Rebel", MaxNumberOfPlayers = 4, MinNumberOfPlayers = 3, PlayingTime = 90, PublishedDate = DateTime.Parse("2015-01-15"), SuggestedAge = 12, Accepted=true},
            new Game{Name = "Wsi¹œæ do Poci¹gu: Europa", CategoryId = 6, Description = " Ticket to Ride Europe to nowa wersja bestsellerowej gry Ticket to Ride, przeniesiona z obszaru Ameryki Pó³nocnej na Stary Kontynent. Zawiera nie tylko now¹ mapê, ale tak¿e nowe elementy gry, jak tunele, przeprawy promowe czy stacje kolejowe.", Publisher = "Rebel", MaxNumberOfPlayers = 5, MinNumberOfPlayers = 2, PlayingTime = 90, PublishedDate = DateTime.Parse("2015-01-16"), SuggestedAge = 8, Accepted=true},
            new Game{Name = "Steampunk Rally", CategoryId = 8, Description = "Gracze wcielaj¹ siê w znanych z historii naukowców I buduj¹ maszyny, którymi bêd¹ rywalizowali w wyœcigu.", Publisher = "Roxley ", MaxNumberOfPlayers = 8, MinNumberOfPlayers = 2, PlayingTime = 60, PublishedDate = DateTime.Parse("2015-01-16"), SuggestedAge = 8, Accepted=true},
            new Game{Name = "Gilotyna", CategoryId = 2, Description = "Gracze wcielaj¹ siê w znanych z historii naukowców I buduj¹ maszyny, którymi bêd¹ rywalizowali w wyœcigu.", Publisher = "Wizard", MaxNumberOfPlayers = 5, MinNumberOfPlayers = 2, PlayingTime = 30, PublishedDate = DateTime.Parse("2015-01-16"), SuggestedAge = 8, Accepted=true},
            new Game{Name = "Dixit", CategoryId = 7, Description = "Gra wyobraŸni. Wspania³a zabawa w obrazkowe kalambury. Czy zgadniesz co inni gracze mieli na myœli?", Publisher = "Rebel", MaxNumberOfPlayers = 6, MinNumberOfPlayers = 3, PlayingTime = 30, PublishedDate = DateTime.Parse("2015-01-17"), SuggestedAge = 8, Accepted=true},
            new Game{Name = "Gra o Tron", CategoryId = 8, Description = "When you play the game of thrones, you win or you die. There is no middle ground.", Publisher = "Galakta", MaxNumberOfPlayers = 6, MinNumberOfPlayers = 3, PlayingTime = 180, PublishedDate = DateTime.Parse("2015-01-18"), SuggestedAge = 12, Accepted=true},
            new Game{Name = "Listy z Whitechapel", CategoryId = 3, Description ="Rok 1888, dzielnica Whitechapel, tajemniczy morderca zabija w brutalny sposób prostytuki. Czy zdo³a przechytrzyæ patrole policji?", Publisher = "Galakta", MaxNumberOfPlayers = 6, MinNumberOfPlayers = 2, PlayingTime = 120, PublishedDate = DateTime.Parse("2015-01-19"), SuggestedAge = 12, Accepted=true},
            new Game{Name = "1919 The Noble Experiment", CategoryId = 2, Description ="Rok 1919, w Stanach Zjednoczonych wprowadzono prohibicjê. Idealna pora by zaj¹æ siê sprzeda¿¹ whisky.", Publisher = "Black Monk Games", MaxNumberOfPlayers = 5, MinNumberOfPlayers = 2, PlayingTime = 30, PublishedDate = DateTime.Parse("2015-01-20"), SuggestedAge = 12, Accepted=true},
            new Game{Name = "Zimowe Opowieœci", CategoryId = 7, Description ="Zimowe opowieœci to narracyjna gra dla 3 – 7 graczy, którzy wspólnie opowiadaj¹ historiê wojny pomiêdzy si³ami zimy i wiosny. Korzystaj¹ przy tym z kart opowieœci i w³asnej wyobraŸni.", Publisher = "Galakta", MaxNumberOfPlayers = 7, MinNumberOfPlayers = 3, PlayingTime =120, PublishedDate = DateTime.Parse("2015-01-20"), SuggestedAge = 8, Accepted=true},
            new Game{Name = "Story Cubes: Baœnie", CategoryId = 7, Description ="Nie ma z³ych odpowiedzi, jedyne co ciê ogranicza, to twoja w³asna wyobraŸnia. ObudŸ j¹ w sobie i daj siê jej ponieœæ, a fantastyczne opowieœci same zrodz¹ siê w twojej g³owie! ", Publisher = "Rebel", MaxNumberOfPlayers = 12, MinNumberOfPlayers = 2, PlayingTime =10, PublishedDate = DateTime.Parse("2015-01-21"), SuggestedAge = 6, Accepted=true},
            new Game{Name = "Story Cubes: Poszlaki", CategoryId = 7, Description =" Nie ma z³ych odpowiedzi, jedyne co ciê ogranicza, to twoja w³asna wyobraŸnia. ObudŸ j¹ w sobie i daj siê jej ponieœæ, a fantastyczne opowieœci same zrodz¹ siê w twojej g³owie! ", Publisher = "Rebel", MaxNumberOfPlayers = 12, MinNumberOfPlayers = 2, PlayingTime =10, PublishedDate = DateTime.Parse("2015-01-21"), SuggestedAge = 6, Accepted=true},
            new Game{Name = "Royals", CategoryId = 8, Description ="XVII wiek, walcz o wp³ywy europejskich szlachciców, to w³aœnie one pozwol¹ byæ najpotê¿niejsz¹ postaci¹ w Europie.", Publisher = "Abacus Spiele", MaxNumberOfPlayers = 5, MinNumberOfPlayers = 2, PlayingTime = 60, PublishedDate = DateTime.Parse("2015-01-21"), SuggestedAge = 12, Accepted=true},
            new Game{Name = "Rokoko", CategoryId = 5, Description ="Król Ludwik XV organizuje przyjêcie. Celem graczy jest uszycie stroi na bal, przygotowanie ozdób oraz fajerewerek.", Publisher = "Hobbity.eu", MaxNumberOfPlayers = 5, MinNumberOfPlayers = 2, PlayingTime = 120, PublishedDate = DateTime.Parse("2015-01-22"), SuggestedAge = 8, Accepted=true},
            new Game{Name = "Trickerion", CategoryId = 8, Description ="W mieœcie Magorium Iluzjoniœci rywalizuj¹ miêdzy sob¹ o miano najlepszego. Czy bêdzie nim mechanik, mistrz ³añcuchów, oszust oczu czy piêkna spirytualistka?", Publisher = "Mindclash Games", MaxNumberOfPlayers = 4, MinNumberOfPlayers = 2, PlayingTime = 150, PublishedDate = DateTime.Parse("2015-01-23"), SuggestedAge = 12, Accepted=true},
            new Game{Name = "Shinobi", CategoryId = 2, Description =" W grze Shinobi gracze wcielaj¹ siê w role tajnych agentów najpotê¿niejszych klanów feudalnej Japonii. Wszystkie klany walcz¹ o dominacjê w kraju, chc¹c zjednoczyæ Japoniê pod swoim sztandarem. ", Publisher = "G3", MaxNumberOfPlayers = 5, MinNumberOfPlayers = 3, PlayingTime = 15, PublishedDate = DateTime.Parse("2015-01-24"), SuggestedAge = 10, Accepted=true},
            new Game{Name = "Takenoko", CategoryId = 6, Description ="Pokonaj g³ód œwiêtej Pandy! Dawno dawno temu, na japoñskim cesarskim dworze…", Publisher = "Rebel", MaxNumberOfPlayers = 4, MinNumberOfPlayers = 2, PlayingTime = 60, PublishedDate = DateTime.Parse("2015-01-25"), SuggestedAge = 8, Accepted=true},
            new Game{Name = "Battlestar Galactica ", CategoryId = 3, Description =" Cyloni zostali stworzeni przez ludzi. Zbuntowali siê. Wyewoluowali. I maj¹ plan.", Publisher = "Galakta", MaxNumberOfPlayers = 6, MinNumberOfPlayers = 3, PlayingTime = 150, PublishedDate = DateTime.Parse("2015-01-26"), SuggestedAge = 12, Accepted=true},
            new Game{Name = "¯ó³w i Zaj¹c", CategoryId = 6, Description ="Wielki wyœcig, bior¹ w nim udzia³ zarówno Zaj¹c i ¯ó³w, ale równie¿ Owieczka, Wilk i Lis. Kto tym razem bêdzie najszybszy?.", Publisher = "Iello", MaxNumberOfPlayers = 5, MinNumberOfPlayers = 2, PlayingTime =30, PublishedDate = DateTime.Parse("2015-01-26"), SuggestedAge = 8, Accepted=true},
            new Game{Name = "Coup ", CategoryId = 2, Description ="Akcja gry Coup ma swoje miejsce w niedalekiej przysz³oœci, gdzie rz¹dy funkcjonuj¹ wy³¹cznie dla zysku, a tylko nieliczni maj¹ wp³yw na swoje ¿ycie.", Publisher = "Galakta", MaxNumberOfPlayers = 6, MinNumberOfPlayers = 2, PlayingTime = 10, PublishedDate = DateTime.Parse("2015-01-27"), SuggestedAge = 12, Accepted=true},
            new Game{Name = "Monster & Maidens ", CategoryId = 4, Description =" Monsters and Maidens is a fun, easy-to-learn dice game with nine fully customized six-sided dice. Players play the role of the Hero trying to rescue the Maidens from the Monsters.", Publisher = "Game Salute", MaxNumberOfPlayers = 6, MinNumberOfPlayers = 2, PlayingTime = 10, PublishedDate = DateTime.Parse("2015-01-28"), SuggestedAge = 8, Accepted=true},
            new Game{Name = "Kameleon", CategoryId = 2, Description ="Graj¹cy doci¹gaj¹ karty ze stosu znajduj¹cego siê na œrodku sto³u. W trakcie rozgrywki gracze staraj¹ siê wyspecjalizowaæ w kilku kolorach, poniewa¿ na koñcu gry otrzymuj¹ punkty tylko za 3, wybrane przez siebie, kolory.", Publisher = "G3", MaxNumberOfPlayers = 5, MinNumberOfPlayers = 2, PlayingTime = 15, PublishedDate = DateTime.Parse("2015-01-29"), SuggestedAge = 8, Accepted=true},
            new Game{Name = "Ucho Króla", CategoryId = 2, Description ="Z nieznanego Ÿród³a wyp³ynê³a informacja o ciê¿kiej chorobie urzêdnika królewskiego odpowiedzialnego za finanse pañstwa. Intratna posada jest na wyci¹gniêcie rêki.", Publisher = "G3", MaxNumberOfPlayers = 6, MinNumberOfPlayers = 2, PlayingTime = 45, PublishedDate = DateTime.Parse("2015-01-30"), SuggestedAge = 8, Accepted=true},
            new Game{Name = "Infiltration", CategoryId = 1, Description ="W Infiltration dwóch do szeœciu graczy, w pe³nej napiêcia rywalizacji przyjmuje role z³odziei,  konkuruj¹cych w gromadzeniu niezwykle wartoœciowych informacji z dobrze chronionych obiektów korporacji.", Publisher = "FFG", MaxNumberOfPlayers = 6, MinNumberOfPlayers = 2, PlayingTime = 45, PublishedDate = DateTime.Parse("2015-01-31"), SuggestedAge = 8, Accepted=true},
            new Game{Name = "7 Cudów Œwiata", CategoryId = 2, Description ="Zostañ przywódc¹ jednego z siedmiu wielkich miast œwiata antycznego. Zbieraj surowce ze swoich ziem, weŸ udzia³ w odwiecznym wyœcigu cywilizacyjnym, nawi¹¿ kontakty handlowe i stwórz militarn¹ potêgê. Pozostaw œlad na kartach historii buduj¹c cud architektury, który przetrwa wieki!", Publisher = "Rebel", MaxNumberOfPlayers = 7, MinNumberOfPlayers = 2, PlayingTime = 30, PublishedDate = DateTime.Parse("2015-02-01"), SuggestedAge = 8, Accepted=true},
            new Game{Name = "Dinopody", CategoryId = 2, Description ="Dinopody to œmieszna i przewrotna karciana gra blefu dla graczy w ka¿dym wieku. Wcielamy siê w pierwotnych ³owców, którzy wspó³zawodnicz¹ o miano najlepszego myœliwego plemienia. Zadaniem graczy jest jak najszybsze pozbycie siê wszystkich kart z rêki.", Publisher = "CUBE", MaxNumberOfPlayers = 7, MinNumberOfPlayers = 2, PlayingTime = 15, PublishedDate = DateTime.Parse("2015-02-02"), SuggestedAge = 8, Accepted=true},
            new Game{Name = "Pokój 25", CategoryId = 3, Description ="Jesteœ uwiêziony w budynku, w którym ka¿de z pomieszczeñ posiada czworo drzwi. Twoim celem jest odnalezienie pokoju 25, który prowadzi do wyjœcia z tego koszmaru.", Publisher = "Rebel", MaxNumberOfPlayers = 6, MinNumberOfPlayers = 1, PlayingTime =45, PublishedDate = DateTime.Parse("2015-02-02"), SuggestedAge = 12, Accepted=true},
            new Game{Name = "List Mi³osny", CategoryId = 2, Description ="Przeka¿ swój list ksiê¿niczce Annette i nie pozwól na to innym graczom. Mocne karty przynosz¹ szybk¹ korzyœæ, ale czyni¹ z ciebie cel. Z drugiej strony, poleganie zbyt d³ugo na s³abych kartach skoñczy siê tym, ¿e twój list wyl¹duje w kominku Ksiê¿niczki.", Publisher = "Bard", MaxNumberOfPlayers = 4, MinNumberOfPlayers = 2, PlayingTime = 15, PublishedDate = DateTime.Parse("2015-02-03"), SuggestedAge = 8, Accepted=true},
            new Game{Name = "Fasolki", CategoryId = 2, Description ="Ka¿dy z graczy ma za zadanie zebraæ jak najwiêcej monet, które uzyskuje siê spieniê¿aj¹c posadzone fasolki. Fasolek jest 8 rodzajów, a ka¿dy z graczy ma tylko 2 poletka.", Publisher = "G3", MaxNumberOfPlayers = 5, MinNumberOfPlayers = 3, PlayingTime = 30, PublishedDate = DateTime.Parse("2015-02-04"), SuggestedAge = 8, Accepted=true},

            };


            games.ForEach(s => context.Games.Add(s));
            context.SaveChanges();


            var rates = new List<Rate>
            {
            new Rate{ GameId = 1,  UserId = 1, Value=6, PublishedDate = DateTime.Parse("2015-01-21")},
            new Rate{ GameId = 1,  UserId = 2, Value=5, PublishedDate = DateTime.Parse("2015-01-21")},
            new Rate{ GameId = 1,  UserId = 3, Value=3, PublishedDate = DateTime.Parse("2015-01-21")},
            new Rate{ GameId = 2,  UserId = 1, Value=6, PublishedDate = DateTime.Parse("2015-01-22")},
            new Rate{ GameId = 2,  UserId = 2, Value=1, PublishedDate = DateTime.Parse("2015-01-22")},
            new Rate{ GameId = 2,  UserId = 3, Value=6, PublishedDate = DateTime.Parse("2015-01-22")},
            new Rate{ GameId = 3,  UserId = 1, Value=7, PublishedDate = DateTime.Parse("2015-01-23")},
            new Rate{ GameId = 3,  UserId = 2, Value=6, PublishedDate = DateTime.Parse("2015-01-24")},
            new Rate{ GameId = 3,  UserId = 3, Value=6, PublishedDate = DateTime.Parse("2015-01-25")},
            new Rate{ GameId = 4,  UserId = 1, Value=8, PublishedDate = DateTime.Parse("2015-01-26")},
            new Rate{ GameId = 5,  UserId = 1, Value=6, PublishedDate = DateTime.Parse("2015-01-27")},
            new Rate{ GameId = 6,  UserId = 1, Value=4, PublishedDate = DateTime.Parse("2015-01-28")},
            new Rate{ GameId = 7,  UserId = 1, Value=3, PublishedDate = DateTime.Parse("2015-01-28")},
            new Rate{ GameId = 8,  UserId = 1, Value=6, PublishedDate = DateTime.Parse("2015-01-29")},
            new Rate{ GameId = 9,  UserId = 1, Value=5, PublishedDate = DateTime.Parse("2015-01-29")},
            new Rate{ GameId = 10,  UserId = 1, Value=6, PublishedDate = DateTime.Parse("2015-01-29")},
            new Rate{ GameId = 11,  UserId = 1, Value=8, PublishedDate = DateTime.Parse("2015-01-29")},
            new Rate{ GameId = 12,  UserId = 1, Value=5, PublishedDate = DateTime.Parse("2015-01-29")},
            new Rate{ GameId = 13,  UserId = 1, Value=6, PublishedDate = DateTime.Parse("2015-01-29")},
            new Rate{ GameId = 14,  UserId = 1, Value=10, PublishedDate = DateTime.Parse("2015-01-30")},
            new Rate{ GameId = 15,  UserId = 1, Value=7, PublishedDate = DateTime.Parse("2015-01-31")},
            new Rate{ GameId = 16,  UserId = 1, Value=7, PublishedDate = DateTime.Parse("2015-02-01")},
            new Rate{ GameId = 17,  UserId = 1, Value=8, PublishedDate = DateTime.Parse("2015-02-02")},
            new Rate{ GameId = 18,  UserId = 1, Value=7, PublishedDate = DateTime.Parse("2015-02-03")},
            new Rate{ GameId = 19,  UserId = 1, Value=3, PublishedDate = DateTime.Parse("2015-02-04")},
            
            };


            rates.ForEach(s => context.Rates.Add(s));
            context.SaveChanges();


            var comments = new List<Comment>
            {
            new Comment{PublishedDate = DateTime.Parse("2015-01-01"), GameId = 1, Content = "Super gra.", UserId = 1},
            new Comment{PublishedDate = DateTime.Parse("2015-01-02"), GameId = 2, Content = "Kiepska. Nie podoba³a mi siê", UserId =2},
            new Comment{PublishedDate = DateTime.Parse("2015-01-03"), GameId = 3, Content = "Bomba!", UserId = 1},
            new Comment{PublishedDate = DateTime.Parse("2015-02-01"), GameId = 1, Content = "Moja ulubiona gra.", UserId = 1},
            new Comment{PublishedDate = DateTime.Parse("2015-02-02"), GameId = 2, Content = "Piêkne grafiki, warto zagraæ.", UserId =2},
            new Comment{PublishedDate = DateTime.Parse("2015-02-03"), GameId = 3, Content = "Ciuch, ciuch.", UserId = 1},
            new Comment{PublishedDate = DateTime.Parse("2015-02-03"), GameId = 4, Content = "Fajnie, ¿e wœród wynalazców jest Polka - Maria Curie.", UserId = 1},
            new Comment{PublishedDate = DateTime.Parse("2015-02-04"), GameId = 5, Content = "Œcinanie g³ów francuskim szlachcicom, fajnie!", UserId = 1},
           
            };


            comments.ForEach(s => context.Comments.Add(s));
            context.SaveChanges();


            var reviews = new List<Review>
            {
            new Review{PublishedDate = DateTime.Parse("2015-02-01"), GameId = 1, Title = "Magiczna przygoda" ,Content = "Droga do korony jest jednak zdradziecka. Wed³ug podañ, w krainie le¿¹cej za Tajemnymi Wrotami ochroni ciê tylko legendarny Talizman. Odnalezienie takiego artefaktu to nie lada wyczyn: na ka¿dym kroku bêd¹ ciê przeœladowaæ potwory, pu³apki i z³owroga magia.", UserId = 1, Accepted=true},
            new Review{PublishedDate = DateTime.Parse("2015-02-02"), GameId = 2, Title = "Wikingowie", Content = "Rozgrywka toczy siê przy u¿yciu sugestywnych figurek drakkarów i potwora morskiego na planszy przedstawiaj¹cej morze otoczone fjordami. Gracze maj¹ do dyspozycji karty, które pozwalaj¹ im ¿eglowaæ swoimi okrêtami, wpêdzaæ innych w k³opoty i kompletowaæ sk³ad swojej za³ogi, która znacz¹co poszerza mo¿liwoœci gracza.", UserId = 1, Accepted=true},
            new Review{PublishedDate = DateTime.Parse("2015-02-03"), GameId = 3, Title = "Kolej¹ po Europie", Content = "Od wzgórz Edynburga, poprzez Pary¿ i Warszawê, do s³onecznego Konstyntantynopola, od alejek Pamplony do stacji Berlina - Ticket to Ride Europe pozwala Ci na zupe³nie now¹ przygodê na mapie Europy pocz¹tków XX wieku.", UserId = 1, Accepted=true},
            new Review{PublishedDate = DateTime.Parse("2015-01-04"), GameId = 4, Title = "Mecha-wyœcig", Content = "Budujemy pojazd. Rzucamy koœæmi i wyœcigujemy siê do mety. Polecam!", UserId = 1, Accepted=false},
            };


            reviews.ForEach(s => context.Reviews.Add(s));
            context.SaveChanges();


            var newses = new List<News>
            {
            new News{PublishedDate = DateTime.Parse("2014-11-25"), Title="Polska edycja Sons of Anarchy", UserId=2, Content="Wydawnictwo Black Monk Games poinformowa³o o rozpoczêciu prac nad polsk¹ edycj¹ gry planszowej Sons Of Anarchy: Men of Mayhem, opartej na serialu telewizyjnym o tym samym tytule. W grze Sons of Anarchy: Men of Mayhem, gracze kontroluj¹ rywalizuj¹ce ze sob¹ gangi, walcz¹ce o dominacjê i wp³ywy w pó³nocnej Kalifornii. W ka¿dej turze, przywódcy gangów wybieraj¹, o które ga³êzie interesów i terytoria bêd¹ walczyæ. Szerokie wp³ywy daj¹ dostêp do nielegalnej broni, kontrabandy i brudnych pieniêdzy, niezbêdnych do zwyciêstwa. Jednak bez uk³adów, chwilowych sojuszy i zastraszania, dominacja mo¿e okazaæ siê ulotna, a wygrana bardzo utrudniona. Znajomoœæ serialu nie jest niezbêdna, aby czerpaæ przyjemnoœæ z gry."},
            new News{PublishedDate = DateTime.Parse("2014-11-27"), Title="REBEL na 2015", UserId=2, Content="Wydawnictwo REBEL.pl ujawni³o swoje pierwsze plany wydawnicze na rok 2015. Na razie potwierdzono wydanie 7 gier: Komiks, Greed, Space Alert, Œpi¹ce Królewny, Takie ¯ycie 2: Detektywi, Mamy Szpiega! i Colt Express. Jak zapewnia wydawnictwo, nie s¹ to wszystkie tytu³y, które uka¿¹ siê jego nak³adem w przysz³ym roku."},
            new News{PublishedDate = DateTime.Parse("2014-11-28"), Title="07 zg³oœ siê", UserId=2, Content="Wydawnictwo Phalanx Games wspólnie z TVP wyda³o grê planszow¹ 07 Zg³oœ siê."},
            new News{PublishedDate = DateTime.Parse("2014-11-29"), Title="Polska edycja SW: Imperial Assault", UserId=2, Content="Wydawnictwo Galakta informuje, ¿e wkrótce jego nak³adem uka¿e siê polska edycja gry Star Wars: Imperial Assault."},
            new News{PublishedDate = DateTime.Parse("2014-12-04"), Title="Aqua Brunch od Factory of Ideas", UserId=2, Content="Nak³adem wydawnictwa Cube - Factory of Ideas, jeszcze w tym roku uka¿e siê prosta gra karciana - Aqua Brunch."},
            new News{PublishedDate = DateTime.Parse("2014-12-04"), Title="Pe³ne œledztwo w tajemniczym domostwie", UserId=2, Content="Na stronie wydawnictwa Portal Games pojawi³ siê nowy wariant do gry Tajemnicze Domostwo, zatytu³owany Pe³ne Œledztwo."},
            new News{PublishedDate = DateTime.Parse("2014-12-09"), Title="XCOM od Galakty", UserId=2, Content="Galakta poinformowa³a o wydaniu polskiej wersji gry XCOM bazuj¹cej na popularnej serii gier komputerowych."},
            new News{PublishedDate = DateTime.Parse("2014-12-18"), Title="Karciany Doctor Who coraz bli¿ej", UserId=2, Content="Jak informuje wydawnictwo Cubicle 7, druga edycja karcianej gry Doctor Who The Card Game jeszcze w tym tygodniu trafi do sklepów w USA. Ze strony wydawcy mo¿na pobraæ instrukcjê do niej."},
            new News{PublishedDate = DateTime.Parse("2015-01-10"), Title="Drakon powraca", UserId=2, Content="Na stronie wydawnictwa Fantasy Flight Games pojawi³a siê zapowiedŸ wznowienia gry planszowej Drakon, w której bohaterowie penetruj¹ zapomniane podziemia w poszukiwaniu skarbów, staraj¹c siê unikn¹æ po¿arcia przez tytu³ow¹ smoczycê."},
            new News{PublishedDate = DateTime.Parse("2015-01-16"), Title="Gostkon 2015 ju¿ w lutym ", UserId=2, Content="Gostyñski Festiwal Fantastyki Gostkon zbli¿a siê wielkimi krokami. Ju¿ 7 i 8 lutego miastem na po³udniu Wielkopolski zaw³adn¹ fani fantastyki. To najwiêkszy konwent na po³udnie od Poznania i na pó³noc od Wroc³awia."},
            new News{PublishedDate = DateTime.Parse("2015-01-17"), Title="Mistrzostwa polski w Splendor ", UserId=2, Content="Wydawnictwo REBEL.pl zaprasza wszystkich do udzia³u w Mistrzostwach Polski Splendor. Eliminacje odbywaj¹ siê w ca³ej Polsce do listopada 2015r. Zwyciêzcy eliminacji wezm¹ udzia³ w wielkim finale w Gdañsku, gdzie do wygrania bêdzie g³ówna nagroda - 1000z³. W samych eliminacjach mo¿na wygraæ gry rzeczonego wydawnictwa."},
            new News{PublishedDate = DateTime.Parse("2015-01-31"), Title="Las od Galakty", UserId=2, Content="Wydawnictwo Galakta informuje, ¿e w okresie letnim jego nak³adem uka¿e siê nowe rozszerzenie do gry Talisman: Magia i Miecz zatytu³owane Las."},

           
            };


            newses.ForEach(s => context.News.Add(s));
            context.SaveChanges();





        }
    }
}

