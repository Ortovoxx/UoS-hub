const User = require('../../db/models/User');
const catchAsync = require('../../utils/catchAsync');
const { fetchCalender } = require('../functions/calendar');

exports.fetch = catchAsync(async (req, res, next) => {
    // const users = await User.find();

    if (!req.query.ical) throw new Error('Failure!');

    console.log(req.query);

    const events = await fetchCalender('https://timetable.soton.ac.uk/Feed/Index/YGPoEcdB6XnwZiEJO3dST0kO-oLE3HsBPis6fBbqsAZy-h13LFkvnqVi4aNsiIgu4fTYijNd-dTUGVm-U9DSNA2');
    
    console.log(events);

    // SEND RESPONSE
    res.status(200).json({
        status: 'success',
        results: events.length,
        data: {
            events,
        },
    });
});