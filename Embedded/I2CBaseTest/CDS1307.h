#pragma once
#include "I2CBase.h"

/// <summary>
/// DS1307 RTC I2C class
/// </summary>
class CDS1307 :
    public I2CBase
{
public:
    enum { DefaultAddress = 0xD0}; // D0 for write and d1 for read.
    struct Time
    {
        int hours;
        int minutes;
        int seconds;
        Time (const int h = 0, const int m = 0, const int s = 0)
            : hours(h), minutes(m), seconds(s)
        {}
    };
    struct Time12 : public Time
    {
        bool isPM;
        Time12(const int h = 0, const int m = 0, const int s = 0)   // Accepts the time is 24 hour format.
            : Time(h, m, s)
            , isPM(h > 11)          // 12 is in the PM
        {
            if (isPM && hours > 12) // 12 is 0PM, but not displayed like that.
            {
                hours -= 12;
            }
        }
        Time12(const int h, const int m, const int s, bool pm)        // Accepts time in 12 hour format
            : Time(h, m, s)
            , isPM(pm)
        {}
        Time12(const Time& t)
            : Time12(t.hours, t.minutes, t.seconds)
        {}
    };

public:
    CDS1307(const byte moduleAddress = DefaultAddress);

    REGISTERACCESS(TimeSeconds, 0);
    REGISTERACCESS(TimeMinutes, 1);
    REGISTERACCESS(TimeHours, 2);
    REGISTERACCESS(TimeDay, 3);
    REGISTERACCESS(TimeDate, 4);
    REGISTERACCESS(TimeMonth, 5);
    REGISTERACCESS(TimeYear, 6);
    REGISTERACCESS(TimeControl, 7);

    void reset();

    Time getTime();
    Time12 getTime12();

    bool is24Hour();
    bool isPM();

    int secondsToInt(const byte value) const { return valuetoInt(value, 0x70, 0x0f); }
    int minutesToInt(const byte value) const { return valuetoInt(value, 0x70, 0x0f); }
    int hours24ToInt(const byte value) const { return valuetoInt(value, 0x30, 0x0f); }
    int hours12ToInt(const byte value) const { return valuetoInt(value, 0x10, 0x0f); }
    int daysToInt(const byte value) const { return valuetoInt(value, 0x0, 0x07); }
    int dateToInt(const byte value) const { return valuetoInt(value, 0x30); }
    int monthToInt(const byte value) const { return valuetoInt(value, 0x10); }
    int yearsToInt(const byte value) const { return valuetoInt(value); }

protected:
    int valuetoInt(const byte value, const byte upperMask = 0xf0, const byte lowerMask = 0x0f) const;
};

