using ConsoleApp6;


namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        public static int[] getArrayForMyTestMethod(string k) // преобразование строки из чисел вида "el1, el2, el3" в массив чисел [el1, el2, el3]
        {
            if (k == "") return new int[0];

            string[] arr = k.Split(",");

            int[] arr_int = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                arr_int[i] = int.Parse(arr[i]);
            }

            return arr_int;

        }

        [Test]
        [TestCase("0, -1, 0, -1, 0, -1, 0, -1, -5", "-5, -1, -1, -1, -1, 0, 0, 0, 0")]
        [TestCase("9, 8, 7, 6, 5, 4, 3, 2, 1", "1, 2, 3, 4, 5, 6, 7, 8, 9")]
        [TestCase("-765, 506, 375, -10389, 523, 4876", "-10389, -765, 375, 506, 523, 4876")]
        [TestCase("-6, 6, -3, 3, -2, 2", "-6, -3, -2, 2, 3, 6")]
        [TestCase("", "")]
        public void Test1(string arr, string arr_result)
        {
            int[] arr_int = getArrayForMyTestMethod(arr);
            int[] result = Functions.ex1(arr_int);
            int[] expected_result = getArrayForMyTestMethod(arr_result);
            Assert.AreEqual(result, expected_result);

        }

        [Test]
        [TestCase("123321", true)]
        [TestCase("kazak", true)]
        [TestCase("hello", false)]
        [TestCase("Owlwo", true)]
        [TestCase("level", true)]
        [TestCase("Was it a car or a cat I saw?", false)]
        public void Test2(string palindrome, bool expected_result)
        {
            bool result = Functions.ex2(palindrome);
            Assert.AreEqual(result, expected_result);
        }

        [Test]
        [TestCase(6, 720)]
        [TestCase(-1, 0)]
        [TestCase(0, 1)]
        [TestCase(8, 40320)]
        [TestCase(9, 362880)]
        [TestCase(10, 3628800)]
        public void Test3(int number, int expected_result)
        {

            try
            {
                int result = Functions.ex3(number);
                Assert.AreEqual(result, expected_result);
            }
            catch (Exception ex)
            {
                if (ex.Message == "NotInRange")
                {
                    Assert.Warn(ex.Message);
                }
            }

        }

        [Test]
        [TestCase(1, 0)]
        [TestCase(2, 1)]
        [TestCase(3, 1)]
        [TestCase(4, 2)]
        [TestCase(8, 13)]
        [TestCase(-5, 0)]

        public void Test4(int order, int expected_result)
        {

            try
            {
                int result = Functions.ex4(order);
                Assert.AreEqual(result, expected_result);
            }
            catch(Exception ex)
            {
                if (ex.Message == "NotInRange")
                {
                    Assert.Warn(ex.Message);
                }
            }


        }

        [Test]
        [TestCase("Hello, World!", "W", 8)]
        [TestCase("Hello, World!", "World!", 8)]
        [TestCase("Hello, World!", "ell", 2)]
        [TestCase("Hello, World!", "Hello, World!", 1)]
        [TestCase("Hello, World!", "Hello, world!", -1)]
        [TestCase("Hello, World", "Hello, World!", -1)]
        [TestCase("Hello, World!", "", -1)]
        [TestCase("", "Hello, World!", -1)]
        [TestCase("", "", -1)]

        public void Test5(string text, string sub_text, int expected_result)
        {
            int result = Functions.ex5(text, sub_text);

            Assert.AreEqual(result, expected_result);

        }

        [Test]
        [TestCase(0, false)]
        [TestCase(1, true)]
        [TestCase(2, true)]
        [TestCase(947, true)]
        [TestCase(839, true)]
        [TestCase(738, false)]
        [TestCase(906, false)]
        [TestCase(939, false)]

        public void Test6(int number, bool expected_result)
        {
            try
            {
                bool result = Functions.ex6(number);

                Assert.AreEqual(result, expected_result);
            }
            catch (Exception ex)
            {
                if (ex.Message == "NotInRange") Assert.Warn(ex.Message);
            }
        }

        [Test]
        [TestCase(-3200, -23)]
        [TestCase(0, 0)]
        [TestCase(-57, -75)]
        [TestCase(1000, 1)]
        [TestCase(5734, 4375)]
        [TestCase(56865845, 54856865)]
        [TestCase(-3024, -4203)]

        public void Test7(int number, int expected_result)
        {
            int result = Functions.ex7(number);

            Assert.AreEqual(result, expected_result);

        }

        [Test]
        [TestCase(0, "NotInRange")]
        [TestCase(1, "I")]
        [TestCase(7, "VII")]
        [TestCase(257, "CCLVII")]
        [TestCase(3549, "MMMDXLIX")]
        [TestCase(3799, "MMMDCCXCIX")]
        [TestCase(2971, "MMCMLXXI")]
        [TestCase(3000, "MMM")]
        public void Test8(int number, string expected_result)
        {

            try
            {
                string result = Functions.ex8(number);

                Assert.AreEqual(result, expected_result);
            }

            catch(Exception ex)
            {
                if (ex.Message == "NotInRange") Assert.Warn(ex.Message);
            }

        }


    }
}