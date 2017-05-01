using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Data.Identity;
using Domain.Model;
using Microsoft.SqlServer.Management.Smo;
using User = Domain.Model.User;

namespace Data
{
    public class DatabaseInitializer : DropCreateDatabaseAlways<CrudContext>
    {
        
        protected override void Seed(CrudContext context)
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
            new Game{Name = "Talisman", CategoryId = 1, Description = "Wyprawa do krainy smoków i magii! W tej pełnej przygód grze wyruszysz na niebezpieczną wyprawę po największy skarb, legendarną Koronę Władzy. Wcielisz się w wojownika, kapłana, czarnoksiężnika lub jednego z pozostałych jedenastu bohaterów władających magią lub mieczem.", Publisher = "Galakta", MaxNumberOfPlayers = 6, MinNumberOfPlayers = 2, PlayingTime = 150, PublishedDate = DateTime.Parse("2015-01-14"), SuggestedAge = 12, Accepted=true},
            new Game{Name = "Wikingowie", CategoryId = 1, Description = "Gracze wcielają się w Jarlów wikingów, którzy walczą o władzę nad Północą i koronę Konunga. Władzę zdobędzie ten, który jako pierwszy złupi wszystkie wsie i przywiezie z nich córki thanów do swojego portu, jako symbol uznania jego praw do korony. ", Publisher = "Rebel", MaxNumberOfPlayers = 4, MinNumberOfPlayers = 3, PlayingTime = 90, PublishedDate = DateTime.Parse("2015-01-15"), SuggestedAge = 12, Accepted=true},
            new Game{Name = "Wsiąść do Pociągu: Europa", CategoryId = 6, Description = " Ticket to Ride Europe to nowa wersja bestsellerowej gry Ticket to Ride, przeniesiona z obszaru Ameryki Północnej na Stary Kontynent. Zawiera nie tylko nową mapę, ale także nowe elementy gry, jak tunele, przeprawy promowe czy stacje kolejowe.", Publisher = "Rebel", MaxNumberOfPlayers = 5, MinNumberOfPlayers = 2, PlayingTime = 90, PublishedDate = DateTime.Parse("2015-01-16"), SuggestedAge = 8, Accepted=true},
            new Game{Name = "Steampunk Rally", CategoryId = 8, Description = "Gracze wcielają się w znanych z historii naukowców I budują maszyny, którymi będą rywalizowali w wyścigu.", Publisher = "Roxley ", MaxNumberOfPlayers = 8, MinNumberOfPlayers = 2, PlayingTime = 60, PublishedDate = DateTime.Parse("2015-01-16"), SuggestedAge = 8, Accepted=true},
            new Game{Name = "Gilotyna", CategoryId = 2, Description = "Gracze wcielają się w znanych z historii naukowców I budują maszyny, którymi będą rywalizowali w wyścigu.", Publisher = "Wizard", MaxNumberOfPlayers = 5, MinNumberOfPlayers = 2, PlayingTime = 30, PublishedDate = DateTime.Parse("2015-01-16"), SuggestedAge = 8, Accepted=true},
            new Game{Name = "Dixit", CategoryId = 7, Description = "Gra wyobraźni. Wspaniała zabawa w obrazkowe kalambury. Czy zgadniesz co inni gracze mieli na myśli?", Publisher = "Rebel", MaxNumberOfPlayers = 6, MinNumberOfPlayers = 3, PlayingTime = 30, PublishedDate = DateTime.Parse("2015-01-17"), SuggestedAge = 8, Accepted=true},
            new Game{Name = "Gra o Tron", CategoryId = 8, Description = "When you play the game of thrones, you win or you die. There is no middle ground.", Publisher = "Galakta", MaxNumberOfPlayers = 6, MinNumberOfPlayers = 3, PlayingTime = 180, PublishedDate = DateTime.Parse("2015-01-18"), SuggestedAge = 12, Accepted=true},
            new Game{Name = "Listy z Whitechapel", CategoryId = 3, Description ="Rok 1888, dzielnica Whitechapel, tajemniczy morderca zabija w brutalny sposób prostytuki. Czy zdoła przechytrzyć patrole policji?", Publisher = "Galakta", MaxNumberOfPlayers = 6, MinNumberOfPlayers = 2, PlayingTime = 120, PublishedDate = DateTime.Parse("2015-01-19"), SuggestedAge = 12, Accepted=true},
            new Game{Name = "1919 The Noble Experiment", CategoryId = 2, Description ="Rok 1919, w Stanach Zjednoczonych wprowadzono prohibicję. Idealna pora by zająć się sprzedażą whisky.", Publisher = "Black Monk Games", MaxNumberOfPlayers = 5, MinNumberOfPlayers = 2, PlayingTime = 30, PublishedDate = DateTime.Parse("2015-01-20"), SuggestedAge = 12, Accepted=true},
            new Game{Name = "Zimowe Opowieści", CategoryId = 7, Description ="Zimowe opowieści to narracyjna gra dla 3 – 7 graczy, którzy wspólnie opowiadają historię wojny pomiędzy siłami zimy i wiosny. Korzystają przy tym z kart opowieści i własnej wyobraźni.", Publisher = "Galakta", MaxNumberOfPlayers = 7, MinNumberOfPlayers = 3, PlayingTime =120, PublishedDate = DateTime.Parse("2015-01-20"), SuggestedAge = 8, Accepted=true},
            new Game{Name = "Story Cubes: Baśnie", CategoryId = 7, Description ="Nie ma złych odpowiedzi, jedyne co cię ogranicza, to twoja własna wyobraźnia. Obudź ją w sobie i daj się jej ponieść, a fantastyczne opowieści same zrodzą się w twojej głowie! ", Publisher = "Rebel", MaxNumberOfPlayers = 12, MinNumberOfPlayers = 2, PlayingTime =10, PublishedDate = DateTime.Parse("2015-01-21"), SuggestedAge = 6, Accepted=true},
            new Game{Name = "Story Cubes: Poszlaki", CategoryId = 7, Description =" Nie ma złych odpowiedzi, jedyne co cię ogranicza, to twoja własna wyobraźnia. Obudź ją w sobie i daj się jej ponieść, a fantastyczne opowieści same zrodzą się w twojej głowie! ", Publisher = "Rebel", MaxNumberOfPlayers = 12, MinNumberOfPlayers = 2, PlayingTime =10, PublishedDate = DateTime.Parse("2015-01-21"), SuggestedAge = 6, Accepted=true},
            new Game{Name = "Royals", CategoryId = 8, Description ="XVII wiek, walcz o wpływy europejskich szlachciców, to właśnie one pozwolą być najpotężniejszą postacią w Europie.", Publisher = "Abacus Spiele", MaxNumberOfPlayers = 5, MinNumberOfPlayers = 2, PlayingTime = 60, PublishedDate = DateTime.Parse("2015-01-21"), SuggestedAge = 12, Accepted=true},
            new Game{Name = "Rokoko", CategoryId = 5, Description ="Król Ludwik XV organizuje przyjęcie. Celem graczy jest uszycie stroi na bal, przygotowanie ozdób oraz fajerewerek.", Publisher = "Hobbity.eu", MaxNumberOfPlayers = 5, MinNumberOfPlayers = 2, PlayingTime = 120, PublishedDate = DateTime.Parse("2015-01-22"), SuggestedAge = 8, Accepted=true},
            new Game{Name = "Trickerion", CategoryId = 8, Description ="W mieście Magorium Iluzjoniści rywalizują między sobą o miano najlepszego. Czy będzie nim mechanik, mistrz łańcuchów, oszust oczu czy piękna spirytualistka?", Publisher = "Mindclash Games", MaxNumberOfPlayers = 4, MinNumberOfPlayers = 2, PlayingTime = 150, PublishedDate = DateTime.Parse("2015-01-23"), SuggestedAge = 12, Accepted=true},
            new Game{Name = "Shinobi", CategoryId = 2, Description =" W grze Shinobi gracze wcielają się w role tajnych agentów najpotężniejszych klanów feudalnej Japonii. Wszystkie klany walczą o dominację w kraju, chcąc zjednoczyć Japonię pod swoim sztandarem. ", Publisher = "G3", MaxNumberOfPlayers = 5, MinNumberOfPlayers = 3, PlayingTime = 15, PublishedDate = DateTime.Parse("2015-01-24"), SuggestedAge = 10, Accepted=true},
            new Game{Name = "Takenoko", CategoryId = 6, Description ="Pokonaj głód świętej Pandy! Dawno dawno temu, na japońskim cesarskim dworze…", Publisher = "Rebel", MaxNumberOfPlayers = 4, MinNumberOfPlayers = 2, PlayingTime = 60, PublishedDate = DateTime.Parse("2015-01-25"), SuggestedAge = 8, Accepted=true},
            new Game{Name = "Battlestar Galactica ", CategoryId = 3, Description =" Cyloni zostali stworzeni przez ludzi. Zbuntowali się. Wyewoluowali. I mają plan.", Publisher = "Galakta", MaxNumberOfPlayers = 6, MinNumberOfPlayers = 3, PlayingTime = 150, PublishedDate = DateTime.Parse("2015-01-26"), SuggestedAge = 12, Accepted=true},
            new Game{Name = "Żółw i Zając", CategoryId = 6, Description ="Wielki wyścig, biorą w nim udział zarówno Zając i Żółw, ale również Owieczka, Wilk i Lis. Kto tym razem będzie najszybszy?.", Publisher = "Iello", MaxNumberOfPlayers = 5, MinNumberOfPlayers = 2, PlayingTime =30, PublishedDate = DateTime.Parse("2015-01-26"), SuggestedAge = 8, Accepted=true},
            new Game{Name = "Coup ", CategoryId = 2, Description ="Akcja gry Coup ma swoje miejsce w niedalekiej przyszłości, gdzie rządy funkcjonują wyłącznie dla zysku, a tylko nieliczni mają wpływ na swoje życie.", Publisher = "Galakta", MaxNumberOfPlayers = 6, MinNumberOfPlayers = 2, PlayingTime = 10, PublishedDate = DateTime.Parse("2015-01-27"), SuggestedAge = 12, Accepted=true},
            new Game{Name = "Monster & Maidens ", CategoryId = 4, Description =" Monsters and Maidens is a fun, easy-to-learn dice game with nine fully customized six-sided dice. Players play the role of the Hero trying to rescue the Maidens from the Monsters.", Publisher = "Game Salute", MaxNumberOfPlayers = 6, MinNumberOfPlayers = 2, PlayingTime = 10, PublishedDate = DateTime.Parse("2015-01-28"), SuggestedAge = 8, Accepted=true},
            new Game{Name = "Kameleon", CategoryId = 2, Description ="Grający dociągają karty ze stosu znajdującego się na środku stołu. W trakcie rozgrywki gracze starają się wyspecjalizować w kilku kolorach, ponieważ na końcu gry otrzymują punkty tylko za 3, wybrane przez siebie, kolory.", Publisher = "G3", MaxNumberOfPlayers = 5, MinNumberOfPlayers = 2, PlayingTime = 15, PublishedDate = DateTime.Parse("2015-01-29"), SuggestedAge = 8, Accepted=true},
            new Game{Name = "Ucho Króla", CategoryId = 2, Description ="Z nieznanego źródła wypłynęła informacja o ciężkiej chorobie urzędnika królewskiego odpowiedzialnego za finanse państwa. Intratna posada jest na wyciągnięcie ręki.", Publisher = "G3", MaxNumberOfPlayers = 6, MinNumberOfPlayers = 2, PlayingTime = 45, PublishedDate = DateTime.Parse("2015-01-30"), SuggestedAge = 8, Accepted=true},
            new Game{Name = "Infiltration", CategoryId = 1, Description ="W Infiltration dwóch do sześciu graczy, w pełnej napięcia rywalizacji przyjmuje role złodziei,  konkurujących w gromadzeniu niezwykle wartościowych informacji z dobrze chronionych obiektów korporacji.", Publisher = "FFG", MaxNumberOfPlayers = 6, MinNumberOfPlayers = 2, PlayingTime = 45, PublishedDate = DateTime.Parse("2015-01-31"), SuggestedAge = 8, Accepted=true},
            new Game{Name = "7 Cudów Świata", CategoryId = 2, Description ="Zostań przywódcą jednego z siedmiu wielkich miast świata antycznego. Zbieraj surowce ze swoich ziem, weź udział w odwiecznym wyścigu cywilizacyjnym, nawiąż kontakty handlowe i stwórz militarną potęgę. Pozostaw ślad na kartach historii budując cud architektury, który przetrwa wieki!", Publisher = "Rebel", MaxNumberOfPlayers = 7, MinNumberOfPlayers = 2, PlayingTime = 30, PublishedDate = DateTime.Parse("2015-02-01"), SuggestedAge = 8, Accepted=true},
            new Game{Name = "Dinopody", CategoryId = 2, Description ="Dinopody to śmieszna i przewrotna karciana gra blefu dla graczy w każdym wieku. Wcielamy się w pierwotnych łowców, którzy współzawodniczą o miano najlepszego myśliwego plemienia. Zadaniem graczy jest jak najszybsze pozbycie się wszystkich kart z ręki.", Publisher = "CUBE", MaxNumberOfPlayers = 7, MinNumberOfPlayers = 2, PlayingTime = 15, PublishedDate = DateTime.Parse("2015-02-02"), SuggestedAge = 8, Accepted=true},
            new Game{Name = "Pokój 25", CategoryId = 3, Description ="Jesteś uwięziony w budynku, w którym każde z pomieszczeń posiada czworo drzwi. Twoim celem jest odnalezienie pokoju 25, który prowadzi do wyjścia z tego koszmaru.", Publisher = "Rebel", MaxNumberOfPlayers = 6, MinNumberOfPlayers = 1, PlayingTime =45, PublishedDate = DateTime.Parse("2015-02-02"), SuggestedAge = 12, Accepted=true},
            new Game{Name = "List Miłosny", CategoryId = 2, Description ="Przekaż swój list księżniczce Annette i nie pozwól na to innym graczom. Mocne karty przynoszą szybką korzyść, ale czynią z ciebie cel. Z drugiej strony, poleganie zbyt długo na słabych kartach skończy się tym, że twój list wyląduje w kominku Księżniczki.", Publisher = "Bard", MaxNumberOfPlayers = 4, MinNumberOfPlayers = 2, PlayingTime = 15, PublishedDate = DateTime.Parse("2015-02-03"), SuggestedAge = 8, Accepted=true},
            new Game{Name = "Fasolki", CategoryId = 2, Description ="Każdy z graczy ma za zadanie zebrać jak najwięcej monet, które uzyskuje się spieniężając posadzone fasolki. Fasolek jest 8 rodzajów, a każdy z graczy ma tylko 2 poletka.", Publisher = "G3", MaxNumberOfPlayers = 5, MinNumberOfPlayers = 3, PlayingTime = 30, PublishedDate = DateTime.Parse("2015-02-04"), SuggestedAge = 8, Accepted=true},

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
            new Comment{PublishedDate = DateTime.Parse("2015-01-02"), GameId = 2, Content = "Kiepska. Nie podobała mi się", UserId =2},
            new Comment{PublishedDate = DateTime.Parse("2015-01-03"), GameId = 3, Content = "Bomba!", UserId = 1},
            new Comment{PublishedDate = DateTime.Parse("2015-02-01"), GameId = 1, Content = "Moja ulubiona gra.", UserId = 1},
            new Comment{PublishedDate = DateTime.Parse("2015-02-02"), GameId = 2, Content = "Piękne grafiki, warto zagrać.", UserId =2},
            new Comment{PublishedDate = DateTime.Parse("2015-02-03"), GameId = 3, Content = "Ciuch, ciuch.", UserId = 1},
            new Comment{PublishedDate = DateTime.Parse("2015-02-03"), GameId = 4, Content = "Fajnie, że wśród wynalazców jest Polka - Maria Curie.", UserId = 1},
            new Comment{PublishedDate = DateTime.Parse("2015-02-04"), GameId = 5, Content = "Ścinanie głów francuskim szlachcicom, fajnie!", UserId = 1},
           
            };


            comments.ForEach(s => context.Comments.Add(s));
            context.SaveChanges();


            var reviews = new List<Review>
            {
            new Review{PublishedDate = DateTime.Parse("2015-02-01"), GameId = 1, Title = "Magiczna przygoda" ,Content = "Droga do korony jest jednak zdradziecka. Według podań, w krainie leżącej za Tajemnymi Wrotami ochroni cię tylko legendarny Talizman. Odnalezienie takiego artefaktu to nie lada wyczyn: na każdym kroku będą cię prześladować potwory, pułapki i złowroga magia.", UserId = 1, Accepted=true},
            new Review{PublishedDate = DateTime.Parse("2015-02-02"), GameId = 2, Title = "Wikingowie", Content = "Rozgrywka toczy się przy użyciu sugestywnych figurek drakkarów i potwora morskiego na planszy przedstawiającej morze otoczone fjordami. Gracze mają do dyspozycji karty, które pozwalają im żeglować swoimi okrętami, wpędzać innych w kłopoty i kompletować skład swojej załogi, która znacząco poszerza możliwości gracza.", UserId = 1, Accepted=true},
            new Review{PublishedDate = DateTime.Parse("2015-02-03"), GameId = 3, Title = "Koleją po Europie", Content = "Od wzgórz Edynburga, poprzez Paryż i Warszawę, do słonecznego Konstyntantynopola, od alejek Pamplony do stacji Berlina - Ticket to Ride Europe pozwala Ci na zupełnie nową przygodę na mapie Europy początków XX wieku.", UserId = 1, Accepted=true},
            new Review{PublishedDate = DateTime.Parse("2015-01-04"), GameId = 4, Title = "Mecha-wyścig", Content = "Budujemy pojazd. Rzucamy kośćmi i wyścigujemy się do mety. Polecam!", UserId = 1, Accepted=false},
            };


            reviews.ForEach(s => context.Reviews.Add(s));
            context.SaveChanges();


            var newses = new List<News>
            {
            new News{PublishedDate = DateTime.Parse("2014-11-25"), Title="Polska edycja Sons of Anarchy", UserId=2, Content="Wydawnictwo Black Monk Games poinformowało o rozpoczęciu prac nad polską edycją gry planszowej Sons Of Anarchy: Men of Mayhem, opartej na serialu telewizyjnym o tym samym tytule. W grze Sons of Anarchy: Men of Mayhem, gracze kontrolują rywalizujące ze sobą gangi, walczące o dominację i wpływy w północnej Kalifornii. W każdej turze, przywódcy gangów wybierają, o które gałęzie interesów i terytoria będą walczyć. Szerokie wpływy dają dostęp do nielegalnej broni, kontrabandy i brudnych pieniędzy, niezbędnych do zwycięstwa. Jednak bez układów, chwilowych sojuszy i zastraszania, dominacja może okazać się ulotna, a wygrana bardzo utrudniona. Znajomość serialu nie jest niezbędna, aby czerpać przyjemność z gry."},
            new News{PublishedDate = DateTime.Parse("2014-11-27"), Title="REBEL na 2015", UserId=2, Content="Wydawnictwo REBEL.pl ujawniło swoje pierwsze plany wydawnicze na rok 2015. Na razie potwierdzono wydanie 7 gier: Komiks, Greed, Space Alert, Śpiące Królewny, Takie Życie 2: Detektywi, Mamy Szpiega! i Colt Express. Jak zapewnia wydawnictwo, nie są to wszystkie tytuły, które ukażą się jego nakładem w przyszłym roku."},
            new News{PublishedDate = DateTime.Parse("2014-11-28"), Title="07 zgłoś się", UserId=2, Content="Wydawnictwo Phalanx Games wspólnie z TVP wydało grę planszową 07 Zgłoś się."},
            new News{PublishedDate = DateTime.Parse("2014-11-29"), Title="Polska edycja SW: Imperial Assault", UserId=2, Content="Wydawnictwo Galakta informuje, że wkrótce jego nakładem ukaże się polska edycja gry Star Wars: Imperial Assault."},
            new News{PublishedDate = DateTime.Parse("2014-12-04"), Title="Aqua Brunch od Factory of Ideas", UserId=2, Content="Nakładem wydawnictwa Cube - Factory of Ideas, jeszcze w tym roku ukaże się prosta gra karciana - Aqua Brunch."},
            new News{PublishedDate = DateTime.Parse("2014-12-04"), Title="Pełne śledztwo w tajemniczym domostwie", UserId=2, Content="Na stronie wydawnictwa Portal Games pojawił się nowy wariant do gry Tajemnicze Domostwo, zatytułowany Pełne Śledztwo."},
            new News{PublishedDate = DateTime.Parse("2014-12-09"), Title="XCOM od Galakty", UserId=2, Content="Galakta poinformowała o wydaniu polskiej wersji gry XCOM bazującej na popularnej serii gier komputerowych."},
            new News{PublishedDate = DateTime.Parse("2014-12-18"), Title="Karciany Doctor Who coraz bliżej", UserId=2, Content="Jak informuje wydawnictwo Cubicle 7, druga edycja karcianej gry Doctor Who The Card Game jeszcze w tym tygodniu trafi do sklepów w USA. Ze strony wydawcy można pobrać instrukcję do niej."},
            new News{PublishedDate = DateTime.Parse("2015-01-10"), Title="Drakon powraca", UserId=2, Content="Na stronie wydawnictwa Fantasy Flight Games pojawiła się zapowiedź wznowienia gry planszowej Drakon, w której bohaterowie penetrują zapomniane podziemia w poszukiwaniu skarbów, starając się uniknąć pożarcia przez tytułową smoczycę."},
            new News{PublishedDate = DateTime.Parse("2015-01-16"), Title="Gostkon 2015 już w lutym ", UserId=2, Content="Gostyński Festiwal Fantastyki Gostkon zbliża się wielkimi krokami. Już 7 i 8 lutego miastem na południu Wielkopolski zawładną fani fantastyki. To największy konwent na południe od Poznania i na północ od Wrocławia."},
            new News{PublishedDate = DateTime.Parse("2015-01-17"), Title="Mistrzostwa polski w Splendor ", UserId=2, Content="Wydawnictwo REBEL.pl zaprasza wszystkich do udziału w Mistrzostwach Polski Splendor. Eliminacje odbywają się w całej Polsce do listopada 2015r. Zwycięzcy eliminacji wezmą udział w wielkim finale w Gdańsku, gdzie do wygrania będzie główna nagroda - 1000zł. W samych eliminacjach można wygrać gry rzeczonego wydawnictwa."},
            new News{PublishedDate = DateTime.Parse("2015-01-31"), Title="Las od Galakty", UserId=2, Content="Wydawnictwo Galakta informuje, że w okresie letnim jego nakładem ukaże się nowe rozszerzenie do gry Talisman: Magia i Miecz zatytułowane Las."},

           
            };


            newses.ForEach(s => context.News.Add(s));
            context.SaveChanges();

           
         


        }

    }
}
