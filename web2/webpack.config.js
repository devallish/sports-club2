const path = require("path");
const { AureliaPlugin } = require("aurelia-webpack-plugin");

module.exports = {
  entry: "main",

  output: {                                   // (2)
    path: path.resolve(__dirname, "dist"),
    publicPath: "/dist/",
    filename: "bundle.js"
  },
  devtool: "eval-source-map",
  resolve: {                                  // (3)
    extensions: [".ts", ".js"],
    modules: ["src", "node_modules"].map(x => path.resolve(x)),
  },

  module: {                                   // (4)
    rules: [
      { test: /\.scss$/i, use: ["style-loader", "css-loader", "sass-loader"] },
      { test: /\.ts$/i, use: "ts-loader" },
      { test: /\.html$/i, use: "html-loader" },
    ]
  },  

  plugins: [
    new AureliaPlugin({includeAll: "src"}),                       // (5)
  ],
};