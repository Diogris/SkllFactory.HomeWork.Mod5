namespace SkllFactory.HomeWork.Mod5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var user = GetUserData();
            ShowUserData(user);

            Console.ReadKey();
        }

        private static void ShowUserData((string FirstName, string LastName, double Age, bool HasPet, int PetCount, string[] PetNames, int FavColorsCount, string[] FavColors) user)
        {
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("Имя: {0}:", user.FirstName);
            Console.WriteLine("Фамилия: {0}:", user.LastName);
            Console.WriteLine("Возраст: {0}:", user.Age);
            if (user.HasPet)
            {
                Console.WriteLine("Питомцев: {0}", user.PetCount);
                Console.WriteLine("Их клички:");
                foreach (var item in user.PetNames)
                {
                    Console.WriteLine("- " + item);
                }
            }
            else
            {
                Console.WriteLine("Питомцев нет");
            }
            Console.WriteLine("Люимых цветов: {0}", user.FavColorsCount);
            foreach (var item in user.FavColors)
            {
                    Console.WriteLine("- " + item);
            }
        }

        private static (string FirstName, string LastName, double Age, bool HasPet, int PetCount, string[] PetNames, int FavColorsCount, string[] FavColors) GetUserData()
        {
            (string FirstName, string LastName, double Age, bool HasPet, int PetCount, string[] PetNames, int FavColorsCount, string[] FavColors) user = new();
            Console.WriteLine("Приветствуем Вас, новый пользователь! Расскажите, пожалуйста, о себе:");

            user.FirstName = GetStringDataFromKeyBoard("Введите имя:");
            user.LastName = GetStringDataFromKeyBoard("Введите фамилию:");
            user.Age = GetDoubleDataFromKeyBoard("Введите Ваш возраст:");
            GetPetInformation(out user.HasPet, out user.PetCount, out user.PetNames);
            GetFavColorsInformation(out user.FavColorsCount, out user.FavColors);

            return user;
        }

        private static void GetFavColorsInformation(out int favColorCount, out string[] favColors)
        {
            favColorCount = GetIntDataFromKeyBoard("Введите количество любимых цветов:");
            favColors = new string[favColorCount];
            for (int i = 0; i < favColorCount; i++)
            {
                favColors[i] = GetStringDataFromKeyBoard($"Назовите цвет {i + 1}");
            }

        }

        private static void GetPetInformation(out bool hasPet, out int petCount, out string[] petNames)
        {
            var notCorrected = true;
            hasPet = false;
            petCount = 0;
            petNames = Array.Empty<string>();
            while (notCorrected)
            {
                Console.WriteLine("Имеется ли у Вас питомец? (да/нет):");
                var hasPetString = Console.ReadLine();
                switch (hasPetString)
                {
                    case "да":
                        hasPet = true;
                        petCount = GetIntDataFromKeyBoard("Введите количество питомцев:");
                        petNames = GetPetNames(petCount);
                        notCorrected = false;
                        break;
                    case "нет":
                        notCorrected = false;
                        break;
                    default:
                        PrintNotCorrected();
                        break;
                }
            }
        }

        private static string[] GetPetNames(int petCount)
        {
            var petNames = new string[petCount];
            for (int i = 0; i < petCount; i++)
            {
                petNames[i] = GetStringDataFromKeyBoard($"Введите имя питомца {i + 1}:");
            }

            return petNames;
        }

        private static string GetStringDataFromKeyBoard(string GetMessage)
        {
            var responseMessage = string.Empty;
            var notCorrected = true;
            while (notCorrected)
            {
                Console.WriteLine(GetMessage);
                responseMessage = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(responseMessage))
                {
                    notCorrected = false;
                }
                else
                {
                    PrintNotCorrected();
                }
            }

            return responseMessage;
        }

        private static int GetIntDataFromKeyBoard(string GetMessage)
        {
            var responceMessage = 0;
            var notCorrected = true;
            while (notCorrected)
            {
                Console.WriteLine(GetMessage);
                notCorrected = !int.TryParse(Console.ReadLine(), out responceMessage);
                if (notCorrected)
                {
                    PrintNotCorrected();
                }
                else
                {
                    if (responceMessage == 0)
                    {
                        notCorrected = true;
                    }
                }
            }
            return responceMessage;
        }

        private static double GetDoubleDataFromKeyBoard(string GetMessage)
        {
            var responceMessage = 0.0;
            var notCorrected = true;
            while (notCorrected)
            {
                Console.WriteLine(GetMessage);
                notCorrected = !double.TryParse(Console.ReadLine(), out responceMessage);
                if (notCorrected)
                {
                    PrintNotCorrected();
                }
                else
                {
                    if (responceMessage == 0)
                    {
                        notCorrected = true;
                    }
                }
            }
            return responceMessage;
        }

        private static void PrintNotCorrected()
        {
            Console.WriteLine("Веден некорректный ответ!");
        }
    }
}

