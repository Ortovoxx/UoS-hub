const axios = require('axios');

const fetchCalender = async (iCal) => {
    const res = await axios.get(`https://ical-to-json.herokuapp.com/convert.json?url=${encodeURIComponent(iCal)}`);

    const events = res.data.vcalendar[0].vevent.map(i => {

        const start = new Date(`${i.dtstart.slice(0, 4)}-${i.dtstart.slice(4, 6)}-${i.dtstart.slice(6, 8)}T${i.dtstart.slice(9, 11)}:${i.dtstart.slice(11, 13)}:${i.dtstart.slice(13, 15)}Z`)
        const end = new Date(`${i.dtend.slice(0, 4)}-${i.dtend.slice(4, 6)}-${i.dtend.slice(6, 8)}T${i.dtend.slice(9, 11)}:${i.dtend.slice(11, 13)}:${i.dtend.slice(13, 15)}Z`)
        
        return {
            start: start,
            end: end,
            lengthMs: end.getTime() - start.getTime(),
            summary: i.summary,
            location: i.location,
        }
    });

    console.log(events);

    return events;
}

module.exports = { fetchCalender };