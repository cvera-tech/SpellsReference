const path = require('path');

module.exports = {
    entry: './Components/index.js',
    output: {
        path: path.resolve(__dirname, './Scripts/dist'),
        filename: 'bundle.js'
    },
    module: {
        rules: [
            {
                test: /\.(js|jsx)$/,
                exclude: /node_modules/,
                use: {
                    loader: 'babel-loader'
                }
            }
        ]
    }
};
