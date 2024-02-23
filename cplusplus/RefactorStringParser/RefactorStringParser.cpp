#include <string>
#include <vector>
#include <iostream>
#include <regex>
#include <algorithm>


// Explanation.
//	At work someone presented me with (something similar to) the following code to review.
//  When I looked at the code I saw that it was a hand coded, long way of doing the task and 
//  suggested the alternative.
//  I failed to convince the original author that my version would be better, because I didn't
//  explain why using std::lib functions was preferable in most cases to hand crafted ones.
//  I agree that my code is not trivial and it could have done with additional comments, lesson learned.



/// <summary>
/// The original code.
/// Purpose:
///			Accept a string containing semi colon separated numbers
///			Spaces will be ignored either side of the semicolon
///			All numbers must be between 1 and 65535
///			'Numbers' containing invalid characters will not be parsed.
///			eg:	12345;11111;12121;22222;11QT2
/// </summary>
/// <param name="strInput">A semi colon separated list of numbers</param>
/// <returns>return the list of valid numbers from the input</returns>
std::vector<int> Original_ParseString(const std::string& input)
{
	std::vector<int> results;

	std::vector<std::string> strings;
	int start = 0;
	for (int i = 0; i < strlen(input.c_str()); i++)
	{
		if (input[i] == ';' || i == strlen(input.c_str()) - 1)
		{
			std::string thisString;
			for (int l = start; l < i; l++)
			{
				thisString += input[l];
			}
			start = i + 1;
			strings.push_back(thisString);
		}
	}
	for (std::vector<std::string>::iterator i = strings.begin(); i != strings.end(); i++)
	{
		int thisNumber = 0;
		for (int l = 0; l < i->length(); l++)
		{
			if (isdigit(i->at(l)))
			{
				thisNumber = (thisNumber * 10) + (int)(i->at(l)-'0');
			}
			else
			{
				thisNumber = 0;
			}
		}
		if (thisNumber > 0)
		{
			results.push_back(thisNumber);
		}
	}
	return results;
}

/// <summary>
/// This is my suggested alternative version of the function
/// </summary>
/// <param name="strInput">A semi colon separated list of numbers</param>
/// <returns>return the list of valid numbers from the input</returns>
std::vector<int> New_ParseString(const std::string& strInput)
{
	//const std::regex re("/d*/d*/d*/d*/d*/s*;*/s*");
	const std::regex re("\\d*\\d*\\d*\\d*\\d*[\\s;]*");
//	std::vector<int> result;

	std::cout << strInput << "\n";
	
	auto words_begin = std::sregex_iterator(strInput.begin(), strInput.end(), re);
	auto words_end = std::sregex_iterator();

	std::cout << "Found " << std::distance(words_begin, words_end) << " words:\n";

	for (std::sregex_iterator i = words_begin; i != words_end; ++i)
	{
		std::smatch match = *i;
		std::string match_str = match.str();
		std::cout << match_str << '\n';
	}






	std::vector<int> result;
	std::vector<std::string> output;
	std::copy_if(std::sregex_token_iterator(strInput.cbegin(), strInput.end(), re, -1), std::sregex_token_iterator(),
		//std::back_inserter(output),
		std::ostream_iterator<std::string>(std::cout, " "),
		[](std::string const& s) {return s.size() != 0; });
	
	return result;
}


/// <summary>
/// Display the results.
/// </summary>
/// <param name="header"></param>
/// <param name="results"></param>
void PrintResults(const std::string& header, const std::vector<int>& results)
{
	std::cout << header.c_str() << "\n";
	for (auto iResult = results.begin(); iResult != results.end(); ++iResult)
	{
		std::cout << *iResult << ", ";
	}
	std::cout << "\n";
}

/// <summary>
/// Main Test harness
/// </summary>
/// <returns></returns>
int main()
{
    std::vector<std::string> testData =
    {
        "12345;11111;12121;22222;11QT2;444"
    };

	

    for (auto iTestData = testData.begin(); iTestData != testData.end(); ++iTestData)
    {
       //PrintResults ("Original", Original_ParseString(*iTestData));
	   PrintResults ("Refactored", New_ParseString(*iTestData));
    }

}
