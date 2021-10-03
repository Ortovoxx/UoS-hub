const catchAsync = require('../../utils/catchAsync');

const buildings = require('./result.json')

exports.getAllBuildings = catchAsync(async (req, res, next) => {

    console.log(buildings);

    // SEND RESPONSE
    res.status(200).json({
        status: 'success',
        results: buildings.length,
        data: {
            buildings,
        },
    });
});
