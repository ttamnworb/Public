// RefactorStringParser.cpp : This file contains the 'main' function. Program execution begins and ends there.
//
#include <string>
#include <vector>
#include <iostream>
#include <regex>
#include <algorithm>

/// The original code.
/// Purpose:
///			Accept a string containing semi colon seperated numbers
///			Spaces will be ignored either side of the semicolon
///			All numbers must be between 1 and 65535
///			'Numbers' comtaining invalid characters will not be parsed.
///			eg:	12345;11111;12121;22222;11QT2
/// 
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


std::vector<int> New_ParseString(const std::string& strInput)
{
	const std::regex re("/d*/d*/d*/d*/d*/s*;*/s*");
	std::vector<std::string> output;
	std::copy_if(std::sregex_token_iterator(strInput.cbegin(), strInput.end(), re, -1), std::sregex_token_iterator(),
		std::back_inserter(output),
		[](std::string const& s) {return s.size() != 0; });

}


/// <summary>
/// Display the results.
/// </summary>
/// <param name="header"></param>
/// <param name="results"></param>
void DumpResults(const std::string& header, const std::vector<int>& results)
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
        "12345;11111;12121;22222;11QT2"
    };

	

    for (auto iTestData = testData.begin(); iTestData != testData.end(); ++iTestData)
    {
       DumpResults ("Original", Original_ParseString(*iTestData));
	   DumpResults ("Refactored", New_ParseString(*iTestData));
    }

}
