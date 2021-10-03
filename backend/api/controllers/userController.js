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
		soton_id: req.body.soton_id,
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

exports.updateUser = catchAsync(async (req, res, next) => {

	// 3) Update user document
	const updatedUser = await User.findByIdAndUpdate(
		req.params.id,
		filteredBody,
		{
			new: true,
			runValidators: true,
		}
	);

	res.status(200).json({
		status: 'success',
		data: {
			user: updatedUser,
		},
	});
});

exports.getUser = catchAsync(async (req, res, next) => {
	const user = await User.findById(req.params.id);

	if (!user)
		return res.status(404).json({
			status: 'failed',
			message: `No User found against id ${req.params.id}`,
		});

	res.status(200).json({
		status: 'success',
		user,
	});
});

exports.deleteUser = catchAsync(async (req, res, next) => {
	const deletedUser = await User.findByIdAndDelete(req.params.id);

	if (!deletedUser)
		return res.status(404).json({
			status: 'failed',
			message: `No User found against id ${req.params.id}`,
		});

	res.status(200).json({
		status: 'success',
		user: deletedUser,
	});
});
