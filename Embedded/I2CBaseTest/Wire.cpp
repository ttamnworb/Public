
#include <algorithm>
#include "Wire.h"

/// <summary>
/// Initialise the test harness class.
/// </summary>
/// <param name="baseAddress"></param>
/// <param name="memorySize"></param>
/// <param name="memory"></param>
CWire::CWire()
{
	m_Controller = false;
	m_SlaveAddres = 0;
	m_Transmitting = false;
	m_Address = 0;
}

/// <summary>
/// 
/// </summary>
/// <param name="address"></param>
/// <param name="block"></param>
/// <returns></returns>
bool CWire::addDevice(const uint8_t address, MemoryBlock& block)
{
	if (m_Blocks.find(address) == m_Blocks.end())
	{
		m_Blocks.emplace(address, block);
		return true;
	}
	return false;
}

/// <summary>
/// 
/// Join bus as controller device when address is 0
/// </summary>
/// <param name="slaveAddress"></param>
void	CWire::begin(const byte slaveAddress)
{
	m_SlaveAddres = slaveAddress;
	m_Controller = (m_SlaveAddres == 0);
}

/// <summary>
/// 
/// </summary>
void	CWire::end()
{
	m_Controller = false;
	m_SlaveAddres = 0;
}

/// <summary>
/// 
/// </summary>
/// <param name="address"></param>
void	CWire::beginTransmission(const byte address)
{
	if (!m_Transmitting)
	{
		m_Transmitting = true;
		m_Address = address;
		return;
	}
	std::exception("beginTransmission already transmitting");
}

/// <summary>
/// 
/// </summary>
/// <param name="stop"></param>
/// <returns></returns>
ERV		CWire::endTransmission(const bool stop)
{
	if (m_Transmitting)
	{
		m_Transmitting = false;
		m_Address = 0;
		return ERV::SUCCESS;
	}
	std::exception("endTransmission not transmitting");
}

/// <summary>
/// 
/// </summary>
/// <param name="address"></param>
/// <param name="size"></param>
/// <param name="stop"></param>
/// <returns></returns>
uint8_t	CWire::requestFrom(const byte address, const uint8_t size, const bool stop)	// stop => send stop message and release the bus.
{
	if (!m_Transmitting)
	{
		std::exception("requestFrom not transmitting");
	}
	m_MemoryPosition = address - m_BaseAddress;
	if (available() < size)
	{
		std::exception("requestFrom more requested than available");
	}
	return available();
}

/// <summary>
/// 
/// </summary>
/// <returns></returns>
uint8_t CWire::available()
{
	if (!m_Transmitting)
	{
		std::exception("requestFrom not transmitting");
	}
	return m_MemorySize - m_MemoryPosition;
}

/// <summary>
/// 
/// </summary>
/// <param name="value"></param>
/// <returns></returns>
uint8_t	CWire::write(const byte value)
{
	if (!m_Transmitting)
	{
		std::exception("requestFrom not transmitting");
	}

}

/// <summary>
/// 
/// </summary>
/// <param name="value"></param>
/// <returns></returns>
uint8_t	CWire::write(const String& value)
{
	if (!m_Transmitting)
	{
		std::exception("requestFrom not transmitting");
	}
}

/// <summary>
/// 
/// </summary>
/// <param name="values"></param>
/// <param name="size"></param>
/// <returns></returns>
uint8_t	CWire::write(const byte* values, const uint8_t size)
{
	if (!m_Transmitting)
	{
		std::exception("requestFrom not transmitting");
	}
}

/// <summary>
/// Read the next byte in the memory
/// </summary>
/// <returns></returns>
byte	CWire::read()
{
	if (!m_Transmitting)
	{
		std::exception("requestFrom not transmitting");
	}
	if (m_MemoryPosition < m_MemorySize)
	{
		return m_Memory[m_MemoryPosition++];
	}
	throw std::exception("read failed out of memory");
}

/// <summary>
/// Is the given address a valid 7 bit address
/// If not thrown an exception
/// /// </summary>
/// <param name="address">The address to test</param>
void	CWire::isValidAddress(const byte address)
{
	// TODO
}