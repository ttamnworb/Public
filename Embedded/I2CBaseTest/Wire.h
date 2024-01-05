#pragma once
#include <map>
#include "WProgram.h"
#include "MemoryBlock.h"

enum ERV
{
	SUCCESS,
	DATA_TOO_LONG,
	RX_NAK_ADDRESS,
	RX_NAK_DATA,
	ERROR,
	TIMEOUT
};

class CWire
{
public: 
	CWire();
	bool addDevice(const uint8_t address, MemoryBlock& block);

public:
	void	begin(const byte slaveAddress = 0);						// Join bus as controller device
	void	end();

	void	beginTransmission(const byte address);
	ERV		endTransmission(const bool stop = true);

	uint8_t	requestFrom(const byte address, const uint8_t size, const bool stop = true);	// stop => send stop message and release the bus.
	uint8_t available();

	uint8_t	write(const byte value);
	uint8_t	write(const String& value);
	uint8_t	write(const byte* values, const uint8_t size);

	byte	read();

private:
	void	isValidAddress(const byte address);

private:
	bool m_Controller = false;
	byte m_SlaveAddres = 0;
	bool m_Transmitting = false;
	byte m_Address = 0;

	std::map<uint8_t, MemoryBlock> m_Blocks;
};


