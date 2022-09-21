import { HowLongToBeatService, HowLongToBeatEntry } from 'howlongtobeat';

let hltbService = new HowLongToBeatService();

hltbService.search('Yakuza 0').then(result => console.log(result));

//https://github.com/ckatzorke/howlongtobeat

// Stappenplan wat ik hiermee doet