"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const howlongtobeat_1 = require("howlongtobeat");
let hltbService = new howlongtobeat_1.HowLongToBeatService();
hltbService.search('Yakuza 0').then(result => console.log(result));
//https://github.com/ckatzorke/howlongtobeat
// Stappenplan wat ik hiermee doet
//# sourceMappingURL=howlongtobeat.js.map