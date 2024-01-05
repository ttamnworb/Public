#include "CDS1307.h"

CDS1307::CDS1307(const byte moduleAddress)
    : I2CBase(moduleAddress)
{
    reset();
}

void CDS1307::reset()
{
    setBitTimeSeconds(7, false);        // Enable oscillator
}

int CDS1307::valuetoInt(const byte value, const byte upperMask, const byte lowerMask) const
{
    int returnValue(0);

    const byte lower = value & lowerMask;
    const byte upper = (value & upperMask) >> 4;

    returnValue = (upper * 10) + lower;
    return returnValue;
}

CDS1307::Time CDS1307::getTime()
{
    Time returnValue = Time
        (hours24ToInt(getTimeHours()),
         minutesToInt(getTimeMinutes()),
         secondsToInt(getTimeSeconds()));
    if (!is24Hour() && isPM())
    {
        returnValue.hours += 12;
    }
    return returnValue;
}
CDS1307::Time12 CDS1307::getTime12()
{
    const bool valueIs24h = is24Hour();

    if (valueIs24h)
    {
        return getTime();
    }

    Time12 returnValue = Time12
        (hours12ToInt(getTimeHours()),
         minutesToInt(getTimeMinutes()),
         secondsToInt(getTimeSeconds()),
         isPM());
    return returnValue;
}

bool CDS1307::is24Hour()
{
    return (getBitTimeHours(6) == 0);
}

bool CDS1307::isPM()
{
    return (!is24Hour() & (getBitTimeHours(4) == 1));

}