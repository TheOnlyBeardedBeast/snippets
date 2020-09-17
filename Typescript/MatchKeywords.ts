// Generates a regex, which matches if all the words|wordparts in the search string are also contained somewhere inside the the tested string

export const createSearchRegex = (searchString: string) => {
  const keyWords = searchString
    .trim()
    .split(' ')
    .map(keyWord => `(?=.*${keyWord})`);

  return new RegExp(keyWords.join('') + '.+');
};
