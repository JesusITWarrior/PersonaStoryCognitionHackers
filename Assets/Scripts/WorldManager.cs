using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(DigitalWorldManager))]
[RequireComponent(typeof(RealWorldManager))]
public class WorldManager : MonoBehaviour
{
    [SerializeField]
    private RealWorldManager rm;
    [SerializeField]
    private DigitalWorldManager dm;
    [SerializeField]
    private Text Month, Day;

    public int month, day;
    public AudioSource BGMusic;
    public enum monthNames { January, February, March, April, May, June, July, August, September, October, November, December};
    public monthNames monthName;
    public enum daysOfWeek { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday};
    public daysOfWeek dayName;


    // Start is called before the first frame update
    private void Awake()
    {
        rm = GetComponent<RealWorldManager>();
        dm = GetComponent<DigitalWorldManager>();

    }
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void assignDate()
    {
        //Get month and day from player's character data information
        Month.text = month.ToString();
        Day.text = day.ToString();
    }

    public bool charAvailable()         //Add paramater which takes the information of the character to be checked
    {
        return false;
    }

    public void nextDay()
    {
        if (month == 2)
        {
            if (day != 28)
                day++;
            else
            {
                month++;
                monthName = monthNames.March;
                day = 1;
            }
        }else if ((month < 8 && month % 2 == 1) || (month >=8 && month %2 == 0))
        {
            if (day != 31)
                day++;
            else
            {
                month++;
                day = 1;
                monthName = nextMonth();
            }

        }else if((month < 8 && month % 2 == 0) || (month >=8 && month %2 == 1))
        {
            if (day != 30)
                day++;
            else
            {
                month++;
                day = 1;
                monthName = nextMonth();
            }
        }

        switch (dayName)
        {
            case daysOfWeek.Monday:
                dayName = daysOfWeek.Tuesday;
                break;
            case daysOfWeek.Tuesday:
                dayName = daysOfWeek.Wednesday;
                break;
            case daysOfWeek.Wednesday:
                dayName = daysOfWeek.Thursday;
                break;
            case daysOfWeek.Thursday:
                dayName = daysOfWeek.Friday;
                break;
            case daysOfWeek.Friday:
                dayName = daysOfWeek.Saturday;
                break;
            case daysOfWeek.Saturday:
                dayName = daysOfWeek.Sunday;
                break;
            case daysOfWeek.Sunday:
                dayName = daysOfWeek.Monday;
                break;
        }
    }

    private monthNames nextMonth()
    {
        switch (monthName)
        {
            case monthNames.January:
                return monthNames.February;
            case monthNames.February:
                return monthNames.March;
            case monthNames.March:
                return monthNames.April;
            case monthNames.April:
                return monthNames.May;
            case monthNames.May:
                return monthNames.June;
            case monthNames.June:
                return monthNames.July;
            case monthNames.July:
                return monthNames.August;
            case monthNames.August:
                return monthNames.September;
            case monthNames.September:
                return monthNames.October;
            case monthNames.October:
                return monthNames.November;
            case monthNames.November:
                return monthNames.December;
            case monthNames.December:
                return monthNames.January;
        }
        return monthNames.August;
    }
}
