#pragma once

class MemoryBlock
{
public:
	using ADDRESS = byte;
	using VALUE = byte;

public:
	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="baseAddress"></param>
	/// <param name="length"></param>
	/// <param name="initialValue"></param>
	MemoryBlock(const ADDRESS& baseAddress, const ADDRESS& length, const VALUE& initialValue)
		: m_BaseAddress(baseAddress)
		, m_Length(length)
	{
		m_Memory = new VALUE[m_Length];
		memset(m_Memory, initialValue, m_Length);
	}

	/// <summary>
	/// Destructor
	/// </summary>
	~MemoryBlock()
	{
		if (m_Memory)
		{
			delete[] m_Memory;
		}
	}

	//MemoryBlock(const MemoryBlock) = delete;


	/// <summary>
	/// Is the given address an address within this memory block
	/// </summary>
	/// <param name="address"></param>
	/// <returns></returns>
	bool  isValidAddress(const ADDRESS& address) const 
	{
		return (address - m_BaseAddress < m_Length);
	}

	/// <summary>
	/// Retrieve the value at the given address
	/// Will throw an exception if the address is out of range.
	/// </summary>
	/// <param name="address"></param>
	/// <returns></returns>
	VALUE getValue(const ADDRESS& address) const
	{
		if (isValidAddress(address) && m_Memory)
		{
			return *(m_Memory + getIndex(address));
		}
		throw std::exception("Address out of range");
	}

	/// <summary>
	/// Set the value at the address
	/// </summary>
	/// <param name="address"></param>
	/// <param name="value"></param>
	/// <returns></returns>
	bool  setValue(const ADDRESS& address, const VALUE& value)
	{
		if (isValidAddress(address) && m_Memory)
		{
			m_Memory[getIndex(address)] = value;
			return true;
		}
		return false;
	}

private:

	/// <summary>
	/// Get the index into the memory block for this address
	/// </summary>
	/// <param name="address"></param>
	/// <returns></returns>
	ADDRESS getIndex(const ADDRESS& address) const
	{
		return (address - m_BaseAddress);
	}

private:
	ADDRESS m_BaseAddress = 0;
	ADDRESS m_Length = 0;
	VALUE* m_Memory = nullptr;
};