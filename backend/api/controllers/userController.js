const User = require('../../db/models/User');
const catchAsync = require('../../utils/catchAsync');

const { fetchCalender } = require('../functions/calendar');

exports.createUser = catchAsync(async (req, res, next) => {

	console.log(req.body);

	const events = await fetchCalender(req.body.ical);

	const newUser = await User.create({
		name: req.body.name,
		tag: req.body.tag,
		ical: req.body.ical,
		timetable: events,
		map: {
			favourites: [],
			timetable: events.map(i => {
				return i.location
			})
		},
		hall: req.body.hall,
		school: req.body.school,
	});

	// SEND RESPONSE
	if (!newUser)
		return res.status(400).json({
			status: 'failed',
			message: `Can't create user due to invalid details`,
		});

	res.status(200).json({
		status: 'success',
		user: newUser,
	});
});


exports.getAllUsers = catchAsync(async (req, res, next) => {

	const users = await User.find();

	// SEND RESPONSE
	res.status(200).json({
		status: 'success',
		results: users.length,
		data: {
			users,
		},
	});
});