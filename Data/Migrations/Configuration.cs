
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
            new Game{Name = "Talisman", CategoryId = 1, Description = "Wyprawa do krainy smok�w i magii! W tej pe�nej przyg�d grze wyruszysz na niebezpieczn� wypraw� po najwi�kszy skarb, legendarn� Koron� W�adzy. Wcielisz si� w wojownika, kap�ana, czarnoksi�nika lub jednego z pozosta�ych jedenastu bohater�w w�adaj�cych magi� lub mieczem.", Publisher = "Galakta", MaxNumberOfPlayers = 6, MinNumberOfPlayers = 2, PlayingTime = 150, PublishedDate = DateTime.Parse("2015-01-14"), SuggestedAge = 12, Accepted=true},
            new Game{Name = "Wikingowie", CategoryId = 1, Description = "Gracze wcielaj� si� w Jarl�w wiking�w, kt�rzy walcz� o w�adz� nad P�noc� i koron� Konunga. W�adz� zdob�dzie ten, kt�ry jako pierwszy z�upi wszystkie wsie i przywiezie z nich c�rki than�w do swojego portu, jako symbol uznania jego praw do korony. ", Publisher = "Rebel", MaxNumberOfPlayers = 4, MinNumberOfPlayers = 3, PlayingTime = 90, PublishedDate = DateTime.Parse("2015-01-15"), SuggestedAge = 12, Accepted=true},
            new Game{Name = "Wsi��� do Poci�gu: Europa", CategoryId = 6, Description = " Ticket to Ride Europe to nowa wersja bestsellerowej gry Ticket to Ride, przeniesiona z obszaru Ameryki P�nocnej na Stary Kontynent. Zawiera nie tylko now� map�, ale tak�e nowe elementy gry, jak tunele, przeprawy promowe czy stacje kolejowe.", Publisher = "Rebel", MaxNumberOfPlayers = 5, MinNumberOfPlayers = 2, PlayingTime = 90, PublishedDate = DateTime.Parse("2015-01-16"), SuggestedAge = 8, Accepted=true},
            new Game{Name = "Steampunk Rally", CategoryId = 8, Description = "Gracze wcielaj� si� w znanych z historii naukowc�w I buduj� maszyny, kt�rymi b�d� rywalizowali w wy�cigu.", Publisher = "Roxley ", MaxNumberOfPlayers = 8, MinNumberOfPlayers = 2, PlayingTime = 60, PublishedDate = DateTime.Parse("2015-01-16"), SuggestedAge = 8, Accepted=true},
            new Game{Name = "Gilotyna", CategoryId = 2, Description = "Gracze wcielaj� si� w znanych z historii naukowc�w I buduj� maszyny, kt�rymi b�d� rywalizowali w wy�cigu.", Publisher = "Wizard", MaxNumberOfPlayers = 5, MinNumberOfPlayers = 2, PlayingTime = 30, PublishedDate = DateTime.Parse("2015-01-16"), SuggestedAge = 8, Accepted=true},
            new Game{Name = "Dixit", CategoryId = 7, Description = "Gra wyobra�ni. Wspania�a zabawa w obrazkowe kalambury. Czy zgadniesz co inni gracze mieli na my�li?", Publisher = "Rebel", MaxNumberOfPlayers = 6, MinNumberOfPlayers = 3, PlayingTime = 30, PublishedDate = DateTime.Parse("2015-01-17"), SuggestedAge = 8, Accepted=true},
            new Game{Name = "Gra o Tron", CategoryId = 8, Description = "When you play the game of thrones, you win or you die. There is no middle ground.", Publisher = "Galakta", MaxNumberOfPlayers = 6, MinNumberOfPlayers = 3, PlayingTime = 180, PublishedDate = DateTime.Parse("2015-01-18"), SuggestedAge = 12, Accepted=true},
            new Game{Name = "Listy z Whitechapel", CategoryId = 3, Description ="Rok 1888, dzielnica Whitechapel, tajemniczy morderca zabija w brutalny spos�b prostytuki. Czy zdo�a przechytrzy� patrole policji?", Publisher = "Galakta", MaxNumberOfPlayers = 6, MinNumberOfPlayers = 2, PlayingTime = 120, PublishedDate = DateTime.Parse("2015-01-19"), SuggestedAge = 12, Accepted=true},
            new Game{Name = "1919 The Noble Experiment", CategoryId = 2, Description ="Rok 1919, w Stanach Zjednoczonych wprowadzono prohibicj�. Idealna pora by zaj�� si� sprzeda�� whisky.", Publisher = "Black Monk Games", MaxNumberOfPlayers = 5, MinNumberOfPlayers = 2, PlayingTime = 30, PublishedDate = DateTime.Parse("2015-01-20"), SuggestedAge = 12, Accepted=true},
            new Game{Name = "Zimowe Opowie�ci", CategoryId = 7, Description ="Zimowe opowie�ci to narracyjna gra dla 3 � 7 graczy, kt�rzy wsp�lnie opowiadaj� histori� wojny pomi�dzy si�ami zimy i wiosny. Korzystaj� przy tym z kart opowie�ci i w�asnej wyobra�ni.", Publisher = "Galakta", MaxNumberOfPlayers = 7, MinNumberOfPlayers = 3, PlayingTime =120, PublishedDate = DateTime.Parse("2015-01-20"), SuggestedAge = 8, Accepted=true},
            new Game{Name = "Story Cubes: Ba�nie", CategoryId = 7, Description ="Nie ma z�ych odpowiedzi, jedyne co ci� ogranicza, to twoja w�asna wyobra�nia. Obud� j� w sobie i daj si� jej ponie��, a fantastyczne opowie�ci same zrodz� si� w twojej g�owie! ", Publisher = "Rebel", MaxNumberOfPlayers = 12, MinNumberOfPlayers = 2, PlayingTime =10, PublishedDate = DateTime.Parse("2015-01-21"), SuggestedAge = 6, Accepted=true},
            new Game{Name = "Story Cubes: Poszlaki", CategoryId = 7, Description =" Nie ma z�ych odpowiedzi, jedyne co ci� ogranicza, to twoja w�asna wyobra�nia. Obud� j� w sobie i daj si� jej ponie��, a fantastyczne opowie�ci same zrodz� si� w twojej g�owie! ", Publisher = "Rebel", MaxNumberOfPlayers = 12, MinNumberOfPlayers = 2, PlayingTime =10, PublishedDate = DateTime.Parse("2015-01-21"), SuggestedAge = 6, Accepted=true},
            new Game{Name = "Royals", CategoryId = 8, Description ="XVII wiek, walcz o wp�ywy europejskich szlachcic�w, to w�a�nie one pozwol� by� najpot�niejsz� postaci� w Europie.", Publisher = "Abacus Spiele", MaxNumberOfPlayers = 5, MinNumberOfPlayers = 2, PlayingTime = 60, PublishedDate = DateTime.Parse("2015-01-21"), SuggestedAge = 12, Accepted=true},
            new Game{Name = "Rokoko", CategoryId = 5, Description ="Kr�l Ludwik XV organizuje przyj�cie. Celem graczy jest uszycie stroi na bal, przygotowanie ozd�b oraz fajerewerek.", Publisher = "Hobbity.eu", MaxNumberOfPlayers = 5, MinNumberOfPlayers = 2, PlayingTime = 120, PublishedDate = DateTime.Parse("2015-01-22"), SuggestedAge = 8, Accepted=true},
            new Game{Name = "Trickerion", CategoryId = 8, Description ="W mie�cie Magorium Iluzjoni�ci rywalizuj� mi�dzy sob� o miano najlepszego. Czy b�dzie nim mechanik, mistrz �a�cuch�w, oszust oczu czy pi�kna spirytualistka?", Publisher = "Mindclash Games", MaxNumberOfPlayers = 4, MinNumberOfPlayers = 2, PlayingTime = 150, PublishedDate = DateTime.Parse("2015-01-23"), SuggestedAge = 12, Accepted=true},
            new Game{Name = "Shinobi", CategoryId = 2, Description =" W grze Shinobi gracze wcielaj� si� w role tajnych agent�w najpot�niejszych klan�w feudalnej Japonii. Wszystkie klany walcz� o dominacj� w kraju, chc�c zjednoczy� Japoni� pod swoim sztandarem. ", Publisher = "G3", MaxNumberOfPlayers = 5, MinNumberOfPlayers = 3, PlayingTime = 15, PublishedDate = DateTime.Parse("2015-01-24"), SuggestedAge = 10, Accepted=true},
            new Game{Name = "Takenoko", CategoryId = 6, Description ="Pokonaj g��d �wi�tej Pandy! Dawno dawno temu, na japo�skim cesarskim dworze�", Publisher = "Rebel", MaxNumberOfPlayers = 4, MinNumberOfPlayers = 2, PlayingTime = 60, PublishedDate = DateTime.Parse("2015-01-25"), SuggestedAge = 8, Accepted=true},
            new Game{Name = "Battlestar Galactica ", CategoryId = 3, Description =" Cyloni zostali stworzeni przez ludzi. Zbuntowali si�. Wyewoluowali. I maj� plan.", Publisher = "Galakta", MaxNumberOfPlayers = 6, MinNumberOfPlayers = 3, PlayingTime = 150, PublishedDate = DateTime.Parse("2015-01-26"), SuggestedAge = 12, Accepted=true},
            new Game{Name = "��w i Zaj�c", CategoryId = 6, Description ="Wielki wy�cig, bior� w nim udzia� zar�wno Zaj�c i ��w, ale r�wnie� Owieczka, Wilk i Lis. Kto tym razem b�dzie najszybszy?.", Publisher = "Iello", MaxNumberOfPlayers = 5, MinNumberOfPlayers = 2, PlayingTime =30, PublishedDate = DateTime.Parse("2015-01-26"), SuggestedAge = 8, Accepted=true},
            new Game{Name = "Coup ", CategoryId = 2, Description ="Akcja gry Coup ma swoje miejsce w niedalekiej przysz�o�ci, gdzie rz�dy funkcjonuj� wy��cznie dla zysku, a tylko nieliczni maj� wp�yw na swoje �ycie.", Publisher = "Galakta", MaxNumberOfPlayers = 6, MinNumberOfPlayers = 2, PlayingTime = 10, PublishedDate = DateTime.Parse("2015-01-27"), SuggestedAge = 12, Accepted=true},
            new Game{Name = "Monster & Maidens ", CategoryId = 4, Description =" Monsters and Maidens is a fun, easy-to-learn dice game with nine fully customized six-sided dice. Players play the role of the Hero trying to rescue the Maidens from the Monsters.", Publisher = "Game Salute", MaxNumberOfPlayers = 6, MinNumberOfPlayers = 2, PlayingTime = 10, PublishedDate = DateTime.Parse("2015-01-28"), SuggestedAge = 8, Accepted=true},
            new Game{Name = "Kameleon", CategoryId = 2, Description ="Graj�cy doci�gaj� karty ze stosu znajduj�cego si� na �rodku sto�u. W trakcie rozgrywki gracze staraj� si� wyspecjalizowa� w kilku kolorach, poniewa� na ko�cu gry otrzymuj� punkty tylko za 3, wybrane przez siebie, kolory.", Publisher = "G3", MaxNumberOfPlayers = 5, MinNumberOfPlayers = 2, PlayingTime = 15, PublishedDate = DateTime.Parse("2015-01-29"), SuggestedAge = 8, Accepted=true},
            new Game{Name = "Ucho Kr�la", CategoryId = 2, Description ="Z nieznanego �r�d�a wyp�yn�a informacja o ci�kiej chorobie urz�dnika kr�lewskiego odpowiedzialnego za finanse pa�stwa. Intratna posada jest na wyci�gni�cie r�ki.", Publisher = "G3", MaxNumberOfPlayers = 6, MinNumberOfPlayers = 2, PlayingTime = 45, PublishedDate = DateTime.Parse("2015-01-30"), SuggestedAge = 8, Accepted=true},
            new Game{Name = "Infiltration", CategoryId = 1, Description ="W Infiltration dw�ch do sze�ciu graczy, w pe�nej napi�cia rywalizacji przyjmuje role z�odziei,  konkuruj�cych w gromadzeniu niezwykle warto�ciowych informacji z dobrze chronionych obiekt�w korporacji.", Publisher = "FFG", MaxNumberOfPlayers = 6, MinNumberOfPlayers = 2, PlayingTime = 45, PublishedDate = DateTime.Parse("2015-01-31"), SuggestedAge = 8, Accepted=true},
            new Game{Name = "7 Cud�w �wiata", CategoryId = 2, Description ="Zosta� przyw�dc� jednego z siedmiu wielkich miast �wiata antycznego. Zbieraj surowce ze swoich ziem, we� udzia� w odwiecznym wy�cigu cywilizacyjnym, nawi�� kontakty handlowe i stw�rz militarn� pot�g�. Pozostaw �lad na kartach historii buduj�c cud architektury, kt�ry przetrwa wieki!", Publisher = "Rebel", MaxNumberOfPlayers = 7, MinNumberOfPlayers = 2, PlayingTime = 30, PublishedDate = DateTime.Parse("2015-02-01"), SuggestedAge = 8, Accepted=true},
            new Game{Name = "Dinopody", CategoryId = 2, Description ="Dinopody to �mieszna i przewrotna karciana gra blefu dla graczy w ka�dym wieku. Wcielamy si� w pierwotnych �owc�w, kt�rzy wsp�zawodnicz� o miano najlepszego my�liwego plemienia. Zadaniem graczy jest jak najszybsze pozbycie si� wszystkich kart z r�ki.", Publisher = "CUBE", MaxNumberOfPlayers = 7, MinNumberOfPlayers = 2, PlayingTime = 15, PublishedDate = DateTime.Parse("2015-02-02"), SuggestedAge = 8, Accepted=true},
            new Game{Name = "Pok�j 25", CategoryId = 3, Description ="Jeste� uwi�ziony w budynku, w kt�rym ka�de z pomieszcze� posiada czworo drzwi. Twoim celem jest odnalezienie pokoju 25, kt�ry prowadzi do wyj�cia z tego koszmaru.", Publisher = "Rebel", MaxNumberOfPlayers = 6, MinNumberOfPlayers = 1, PlayingTime =45, PublishedDate = DateTime.Parse("2015-02-02"), SuggestedAge = 12, Accepted=true},
            new Game{Name = "List Mi�osny", CategoryId = 2, Description ="Przeka� sw�j list ksi�niczce Annette i nie pozw�l na to innym graczom. Mocne karty przynosz� szybk� korzy��, ale czyni� z ciebie cel. Z drugiej strony, poleganie zbyt d�ugo na s�abych kartach sko�czy si� tym, �e tw�j list wyl�duje w kominku Ksi�niczki.", Publisher = "Bard", MaxNumberOfPlayers = 4, MinNumberOfPlayers = 2, PlayingTime = 15, PublishedDate = DateTime.Parse("2015-02-03"), SuggestedAge = 8, Accepted=true},
            new Game{Name = "Fasolki", CategoryId = 2, Description ="Ka�dy z graczy ma za zadanie zebra� jak najwi�cej monet, kt�re uzyskuje si� spieni�aj�c posadzone fasolki. Fasolek jest 8 rodzaj�w, a ka�dy z graczy ma tylko 2 poletka.", Publisher = "G3", MaxNumberOfPlayers = 5, MinNumberOfPlayers = 3, PlayingTime = 30, PublishedDate = DateTime.Parse("2015-02-04"), SuggestedAge = 8, Accepted=true},

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
            new Comment{PublishedDate = DateTime.Parse("2015-01-02"), GameId = 2, Content = "Kiepska. Nie podoba�a mi si�", UserId =2},
            new Comment{PublishedDate = DateTime.Parse("2015-01-03"), GameId = 3, Content = "Bomba!", UserId = 1},
            new Comment{PublishedDate = DateTime.Parse("2015-02-01"), GameId = 1, Content = "Moja ulubiona gra.", UserId = 1},
            new Comment{PublishedDate = DateTime.Parse("2015-02-02"), GameId = 2, Content = "Pi�kne grafiki, warto zagra�.", UserId =2},
            new Comment{PublishedDate = DateTime.Parse("2015-02-03"), GameId = 3, Content = "Ciuch, ciuch.", UserId = 1},
            new Comment{PublishedDate = DateTime.Parse("2015-02-03"), GameId = 4, Content = "Fajnie, �e w�r�d wynalazc�w jest Polka - Maria Curie.", UserId = 1},
            new Comment{PublishedDate = DateTime.Parse("2015-02-04"), GameId = 5, Content = "�cinanie g��w francuskim szlachcicom, fajnie!", UserId = 1},
           
            };


            comments.ForEach(s => context.Comments.Add(s));
            context.SaveChanges();


            var reviews = new List<Review>
            {
            new Review{PublishedDate = DateTime.Parse("2015-02-01"), GameId = 1, Title = "Magiczna przygoda" ,Content = "Droga do korony jest jednak zdradziecka. Wed�ug poda�, w krainie le��cej za Tajemnymi Wrotami ochroni ci� tylko legendarny Talizman. Odnalezienie takiego artefaktu to nie lada wyczyn: na ka�dym kroku b�d� ci� prze�ladowa� potwory, pu�apki i z�owroga magia.", UserId = 1, Accepted=true},
            new Review{PublishedDate = DateTime.Parse("2015-02-02"), GameId = 2, Title = "Wikingowie", Content = "Rozgrywka toczy si� przy u�yciu sugestywnych figurek drakkar�w i potwora morskiego na planszy przedstawiaj�cej morze otoczone fjordami. Gracze maj� do dyspozycji karty, kt�re pozwalaj� im �eglowa� swoimi okr�tami, wp�dza� innych w k�opoty i kompletowa� sk�ad swojej za�ogi, kt�ra znacz�co poszerza mo�liwo�ci gracza.", UserId = 1, Accepted=true},
            new Review{PublishedDate = DateTime.Parse("2015-02-03"), GameId = 3, Title = "Kolej� po Europie", Content = "Od wzg�rz Edynburga, poprzez Pary� i Warszaw�, do s�onecznego Konstyntantynopola, od alejek Pamplony do stacji Berlina - Ticket to Ride Europe pozwala Ci na zupe�nie now� przygod� na mapie Europy pocz�tk�w XX wieku.", UserId = 1, Accepted=true},
            new Review{PublishedDate = DateTime.Parse("2015-01-04"), GameId = 4, Title = "Mecha-wy�cig", Content = "Budujemy pojazd. Rzucamy ko��mi i wy�cigujemy si� do mety. Polecam!", UserId = 1, Accepted=false},
            };


            reviews.ForEach(s => context.Reviews.Add(s));
            context.SaveChanges();


            var newses = new List<News>
            {
            new News{PublishedDate = DateTime.Parse("2014-11-25"), Title="Polska edycja Sons of Anarchy", UserId=2, Content="Wydawnictwo Black Monk Games poinformowa�o o rozpocz�ciu prac nad polsk� edycj� gry planszowej Sons Of Anarchy: Men of Mayhem, opartej na serialu telewizyjnym o tym samym tytule. W grze Sons of Anarchy: Men of Mayhem, gracze kontroluj� rywalizuj�ce ze sob� gangi, walcz�ce o dominacj� i wp�ywy w p�nocnej Kalifornii. W ka�dej turze, przyw�dcy gang�w wybieraj�, o kt�re ga��zie interes�w i terytoria b�d� walczy�. Szerokie wp�ywy daj� dost�p do nielegalnej broni, kontrabandy i brudnych pieni�dzy, niezb�dnych do zwyci�stwa. Jednak bez uk�ad�w, chwilowych sojuszy i zastraszania, dominacja mo�e okaza� si� ulotna, a wygrana bardzo utrudniona. Znajomo�� serialu nie jest niezb�dna, aby czerpa� przyjemno�� z gry."},
            new News{PublishedDate = DateTime.Parse("2014-11-27"), Title="REBEL na 2015", UserId=2, Content="Wydawnictwo REBEL.pl ujawni�o swoje pierwsze plany wydawnicze na rok 2015. Na razie potwierdzono wydanie 7 gier: Komiks, Greed, Space Alert, �pi�ce Kr�lewny, Takie �ycie 2: Detektywi, Mamy Szpiega! i Colt Express. Jak zapewnia wydawnictwo, nie s� to wszystkie tytu�y, kt�re uka�� si� jego nak�adem w przysz�ym roku."},
            new News{PublishedDate = DateTime.Parse("2014-11-28"), Title="07 zg�o� si�", UserId=2, Content="Wydawnictwo Phalanx Games wsp�lnie z TVP wyda�o gr� planszow� 07 Zg�o� si�."},
            new News{PublishedDate = DateTime.Parse("2014-11-29"), Title="Polska edycja SW: Imperial Assault", UserId=2, Content="Wydawnictwo Galakta informuje, �e wkr�tce jego nak�adem uka�e si� polska edycja gry Star Wars: Imperial Assault."},
            new News{PublishedDate = DateTime.Parse("2014-12-04"), Title="Aqua Brunch od Factory of Ideas", UserId=2, Content="Nak�adem wydawnictwa Cube - Factory of Ideas, jeszcze w tym roku uka�e si� prosta gra karciana - Aqua Brunch."},
            new News{PublishedDate = DateTime.Parse("2014-12-04"), Title="Pe�ne �ledztwo w tajemniczym domostwie", UserId=2, Content="Na stronie wydawnictwa Portal Games pojawi� si� nowy wariant do gry Tajemnicze Domostwo, zatytu�owany Pe�ne �ledztwo."},
            new News{PublishedDate = DateTime.Parse("2014-12-09"), Title="XCOM od Galakty", UserId=2, Content="Galakta poinformowa�a o wydaniu polskiej wersji gry XCOM bazuj�cej na popularnej serii gier komputerowych."},
            new News{PublishedDate = DateTime.Parse("2014-12-18"), Title="Karciany Doctor Who coraz bli�ej", UserId=2, Content="Jak informuje wydawnictwo Cubicle 7, druga edycja karcianej gry Doctor Who The Card Game jeszcze w tym tygodniu trafi do sklep�w w USA. Ze strony wydawcy mo�na pobra� instrukcj� do niej."},
            new News{PublishedDate = DateTime.Parse("2015-01-10"), Title="Drakon powraca", UserId=2, Content="Na stronie wydawnictwa Fantasy Flight Games pojawi�a si� zapowied� wznowienia gry planszowej Drakon, w kt�rej bohaterowie penetruj� zapomniane podziemia w poszukiwaniu skarb�w, staraj�c si� unikn�� po�arcia przez tytu�ow� smoczyc�."},
            new News{PublishedDate = DateTime.Parse("2015-01-16"), Title="Gostkon 2015 ju� w lutym ", UserId=2, Content="Gosty�ski Festiwal Fantastyki Gostkon zbli�a si� wielkimi krokami. Ju� 7 i 8 lutego miastem na po�udniu Wielkopolski zaw�adn� fani fantastyki. To najwi�kszy konwent na po�udnie od Poznania i na p�noc od Wroc�awia."},
            new News{PublishedDate = DateTime.Parse("2015-01-17"), Title="Mistrzostwa polski w Splendor ", UserId=2, Content="Wydawnictwo REBEL.pl zaprasza wszystkich do udzia�u w Mistrzostwach Polski Splendor. Eliminacje odbywaj� si� w ca�ej Polsce do listopada 2015r. Zwyci�zcy eliminacji wezm� udzia� w wielkim finale w Gda�sku, gdzie do wygrania b�dzie g��wna nagroda - 1000z�. W samych eliminacjach mo�na wygra� gry rzeczonego wydawnictwa."},
            new News{PublishedDate = DateTime.Parse("2015-01-31"), Title="Las od Galakty", UserId=2, Content="Wydawnictwo Galakta informuje, �e w okresie letnim jego nak�adem uka�e si� nowe rozszerzenie do gry Talisman: Magia i Miecz zatytu�owane Las."},

           
            };


            newses.ForEach(s => context.News.Add(s));
            context.SaveChanges();





        }
    }
}

