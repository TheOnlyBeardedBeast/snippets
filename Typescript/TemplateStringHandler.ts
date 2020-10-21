export interface IDictionary<T> {
    [key: string]: T;
}

// use dictionary keys in string inside curly braces "this is the {{key}}" becomes "this is the value" if our dictionary is {"key":"value"}
export const prepareTemplate = (
    template: string,
    replaceDictionary: IDictionary<string>,
) => {
    const replaceKeys = Object.keys(replaceDictionary)
        .map((key) => `{{${key}}}`)
        .join('|');
    const replaceRegex = new RegExp(replaceKeys, 'gi');

    return emailTemplate.replace(
        replaceRegex,
        (match) => replaceDictionary[match.substring(2, match.length - 2)],
    );
};
