'use strict';

/********************************************************************************************
 *                                  РЕГУЛЯРНЫЕ ВЫРАЖЕНИЯ                                    *
 *******************************************************************************************/

/********************************************************************************************
 *                                                                                          *
 * Перед началом выполнения заданий рекомендуем ознакомиться с материалом:                             *
 * https://developer.mozilla.org/ru/docs/Web/JavaScript/Guide/Regular_Expressions           *
 *                                                                                          *
 ********************************************************************************************/


/**
 * Напишите регулярное выражение, которое соотвествует GUID-формату:
 * '{XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX}',
 * где X - это шестнадцатиричное число (0,1,2...,9,A,a,B,b,C,c,D,d,E,e,F,f)
 *
 * Больше деталей можно найти на: https://ru.wikipedia.org/wiki/GUID
 *
 * Соотвествие :
 *   '{3F2504E0-4F89-41D3-9A0C-0305E82C3301}'
 *   '{21EC2020-3AEA-4069-A2DD-08002B30309D}'
 *   '{0c74f13f-fa83-4c48-9b33-68921dd72463}'
 *
 *  Несоотвествие:
 *   '{D44EF4F4-280B47E5-91C7-261222A59621}'
 *   '{D1A5279D-B27D-4CD4-A05E-EFDH53D08E8D}'
 *   '{5EDEB36C-9006-467A8D04-AFB6F62CD7D2}'
 *   '677E2553DD4D43B09DA77414DB1EB8EA'
 *   '0c74f13f-fa83-4c48-9b33-68921dd72463'
 *   'The roof, the roof, the roof is on fire'
 *
 * @return {RegExp}
 */
function getRegexForGuid() {
   throw new Error('Not implemented');
}


/**
 * Напишите регулярное выражение, которое подходит для всех строк слева,
 * но не подходит для всех строк справа
 *
 * Соотвествие :           Несоотвествие :
 * -----------             --------------
 *  'pit'                     ' pt'
 *  'spot'                    'Pot'
 *  'spate'                   'peat'
 *  'slap two'                'part'
 *  'respite'
 *
 * ПРИМЕЧАНИЕ : регулярное выражение не должно превышать по длине 12 символов
 *
 * @return {RegExp}
 *
 */
function getRegexForPitSpot() {
   throw new Error('Not implemented');
}

module.exports = {
   getRegexForGuid: getRegexForGuid,
   getRegexForPitSpot: getRegexForPitSpot,
};